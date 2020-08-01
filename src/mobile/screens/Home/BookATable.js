import React from 'react'
import Container from '../../components/Container';
import { View, ImageBackground, Linking, Dimensions } from 'react-native';
import { Text, StyleService, Icon, Button, Divider, ButtonGroup, TabBar, Tab, Calendar } from '@ui-kitten/components';
import { Splash } from '../Screens';
import axios from '../../axios'
import { colors } from '../../variables/colors';
import { Back, Filter, ShareIcon, PhotoIcon, Heart, PlusIcon, MinusIcon } from '../../components/Icons';
import { TouchableOpacity, ScrollView } from 'react-native-gesture-handler';

import MapView, { MAP_TYPES, Marker, PROVIDER_DEFAULT, UrlTile } from 'react-native-maps';
import MenuHorizontalList from '../../components/Menu/MenuHorizontalList';
import Animated, { interpolate } from 'react-native-reanimated';
import { PinIcon, CalendarIcon, PersonIcon, ClockIcon } from '../../variables/Icons';
import { createStackNavigator } from '@react-navigation/stack';
import RestaurantMenu from './RestaurantMenu';
import moment from 'moment'

import DateTimePicker from '@react-native-community/datetimepicker';
import { material } from 'react-native-typography';
import SingleButton from '../../components/SingleButton';


const { Navigator, Screen } = createStackNavigator()

const nanSymbol = '—'

const shadowStyle = {
    shadowColor: "#000",
    shadowOffset: {
        width: 0,
        height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,

    elevation: 5,
}

const BookATable = (props) => {
    const [restaurant, setRestaurant] = React.useState(null)
    const [selectedIndex, setSelectedIndex] = React.useState(0);

    const [dateIsSelected, setDateIsSelected] = React.useState(false)
    const [timeIsSelected, setTimesIsSelected] = React.useState(false)

    const [date, setDate] = React.useState(new Date())
    const [selectedTime, setSelectedTime] = React.useState(null)
    const [persons, setPersons] = React.useState(nanSymbol)

    const [range, setRange] = React.useState({});

    const [currentStep, setCurrentStep] = React.useState(1)

    const [times, setTimes] = React.useState([
        { category: 'Lunch', times: [['11:30', '12:00', '12:30', '13:00']] },
        { category: 'Dinner', times: [['17:30', '18:00', '18:30', '19:00'], ['19:30', '20:00', '20:30', '21:00']] },
    ])

    const [buttonVisible, setButtonVisible] = React.useState(false)

    const [partySize, setPartySize] = React.useState({
        adults: 0,
        children: 0
    })

    React.useEffect(() => { if (restaurant == null) setRestaurant(props.route.params.restaurant) }, []);

    const PictureHeader = (props) => (
        <View style={{ flexDirection: 'row', justifyContent: 'flex-start' }}>
            <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.white })} />
        </View>
    )

    const selectDate = (nextDate) => {
        setDate(nextDate)
        setDateIsSelected(true)
        setButtonVisible(true)
    }

    const PictureFooter = (props) => (
        <View style={{ paddingHorizontal: 8 }}>
            <Text category='h2' style={{ ...material.display2White, fontWeight: 'bold', color: colors.white }}>{restaurant.title}</Text>
        </View>
    )

    const Continue = () => {
        setCurrentStep(currentStep + 1)

        setButtonVisible(false)
    }

    const SelectTime = (time) => {
        let mTime = moment(time, 'HH:mm')

        let newDate = moment(date).set({
            hour: mTime.hour(),
            minute: mTime.minute(),
        })

        setDate(newDate)
        setSelectedTime(time)
        setTimesIsSelected(true)
        setButtonVisible(true)
    }

    const ChangePartySize = (person, operation) => {
        if (person === 'adult') {
            if (operation === '+') {
                setPartySize({
                    ...partySize,
                    adults: partySize.adults + 1
                })

                setButtonVisible(true)
            } else if (operation === '-') {
                setPartySize({
                    ...partySize,
                    adults: partySize.adults > 1 ? partySize.adults - 1 : partySize.adults
                })
            }
        } else if (person === 'child') {
            if (operation === '+') {
                setPartySize({
                    ...partySize,
                    children: partySize.children + 1
                })
            } else if (operation === '-') {
                setPartySize({
                    ...partySize,
                    children: partySize.children > 0 ? partySize.children - 1 : partySize.children
                })
            }
        }
    }

    return (
        restaurant ? <View style={{ backgroundColor: colors.white, height: '100%' }}>
            <ImageBackground
                style={styles.itemHeader}
                source={{ uri: restaurant.image }}>
                <PictureHeader />

                <PictureFooter />
            </ImageBackground>

            <View style={styles.tabContainer}>
                <TouchableOpacity style={styles.tabButton2}>
                    <CalendarIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, !dateIsSelected && { color: 'grey' }]}>{dateIsSelected ? moment(date).format('DD MMM') : nanSymbol}</Text>
                </TouchableOpacity>
                <Divider style={styles.divider} />
                <TouchableOpacity style={styles.tabButton2} >
                    <ClockIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, !timeIsSelected && { color: 'grey' }]}>{timeIsSelected ? moment(date).format('HH:mm') : nanSymbol}</Text>
                </TouchableOpacity>
                <Divider style={styles.divider} />
                <TouchableOpacity style={styles.tabButton2} onPress={() => setPersons(2)}>
                    <PersonIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, persons === nanSymbol && { color: 'grey' }]}>{persons}</Text>
                </TouchableOpacity>
            </View>

            <ScrollView style={{ paddingTop: 24 }}>
                <Text category='h5' style={{ textAlign: 'center', ...material.title }}>Book a table</Text>
                {currentStep === 1 && ( //{ display: 'flex', flexDirection: 'column', justifyContent: 'space-between' 
                    <View>
                        <View style={styles.calendarContainer}>
                            <Calendar
                                date={date}
                                onSelect={selectDate}
                                style={styles.calendar}
                            />
                        </View>
                    </View>)}
                {currentStep === 2 && (
                    <View>
                        {times.map(_ => (
                            <View style={{ paddingHorizontal: 32 }}>
                                <Text style={{ marginVertical: 16, textAlign: 'center', ...material.subheading }}>{_.category}</Text>
                                {_.times.map(times => (
                                    <View style={{ flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'space-between' }}>
                                        {times.map(time => (
                                            <TouchableOpacity
                                                style={[styles.timeButton, time === selectedTime && { backgroundColor: colors.active }]}
                                                onPress={() => SelectTime(time)}>
                                                <Text style={time === selectedTime ? styles.timeTextActive : styles.timeText}>{time}</Text>
                                            </TouchableOpacity>
                                        ))}
                                    </View>
                                ))}
                            </View>
                        ))}
                    </View>)}
                {currentStep === 3 && (
                    <View>
                        <View style={{ paddingVertical: 24 }}>
                            <Text style={{ textAlign: 'center', ...material.body2 }}>Adults</Text>
                            <View style={styles.amountContainer}>
                                <TouchableOpacity
                                    style={styles.amountButton}
                                    onPress={() => ChangePartySize('adult', '-')}>
                                    <MinusIcon width={24} height={24} fill={colors.green} alignSelf='center' />
                                </TouchableOpacity>
                                <Text style={styles.amount}>{partySize.adults}</Text>
                                <TouchableOpacity
                                    style={styles.amountButton}
                                    onPress={() => ChangePartySize('adult', '+')}>
                                    <PlusIcon width={24} height={24} fill={colors.green} alignSelf='center' />
                                </TouchableOpacity>
                            </View>
                        </View>
                        <View>
                            <Text style={{ textAlign: 'center', ...material.body2 }}>Children</Text>
                            <View style={styles.amountContainer}>
                                <TouchableOpacity
                                    style={styles.amountButton}
                                    onPress={() => ChangePartySize('child', '-')}>
                                    <MinusIcon width={24} height={24} fill={colors.green} alignSelf='center' />
                                </TouchableOpacity>
                                <Text style={styles.amount}>{partySize.children}</Text>
                                <TouchableOpacity
                                    style={styles.amountButton}
                                    onPress={() => ChangePartySize('child', '+')}>
                                    <PlusIcon width={24} height={24} fill={colors.green} alignSelf='center' />
                                </TouchableOpacity>
                            </View>
                        </View>
                    </View>)}
            </ScrollView >
            {buttonVisible && <SingleButton text='Continue' onPress={Continue} style={{ marginVertical: 24 }} />}
        </View > : <Splash />
    )
}

const styles = StyleService.create({
    itemHeader: {
        justifyContent: 'space-between',
        flexDirection: 'column',
        padding: 8,
        height: 150
    },
    iconButton: {
        paddingHorizontal: 0,
        backgroundColor: colors.white,
        width: 16,
        borderRadius: 16,
        top: 20,

        ...shadowStyle,

        alignSelf: 'flex-end',
        marginHorizontal: 16
    },
    detailTexts: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        paddingVertical: 4
    },
    map: {
        height: 120
    },
    tabButton: {
        flexDirection: 'row',
        flex: 1,
        borderRightWidth: 1,
        borderRightColor: 'grey',
        justifyContent: 'flex-start',
        paddingHorizontal: 8,
    },
    tabButtonLast: {
        borderRightWidth: 0
    },
    titleStyle: {
        paddingHorizontal: 8
    },
    tabContainer: {
        backgroundColor: colors.white,
        flexDirection: 'row',
        justifyContent: 'space-evenly',
        ...shadowStyle
    },
    tabButton2: {
        flexDirection: 'row',
        paddingVertical: 16,
        paddingHorizontal: 8
    },
    divider: {
        borderRightColor: 'grey',
        borderRightWidth: 1,
        height: '70%',
        alignSelf: 'center'
    },
    barText: {
        paddingHorizontal: 8,
        color: colors.green
    },
    container: {
        flexDirection: 'row',
        flexWrap: 'wrap',
    },
    calendarContainer: {
    },
    text: {
        marginVertical: 8,
    },
    calendar: {
        width: Dimensions.get('window').width,
        // marginHorizontal: 16,
        borderColor: 'transparent',
    },
    timeButton: {
        backgroundColor: colors.lightGrey,
        borderRadius: 32,
        height: 32,
        width: 56,
        flexDirection: 'column',
        justifyContent: 'center',
        marginBottom: 16
    },
    timeText: {
        ...material.caption,
        textAlign: 'center',
        fontWeight: 'bold'
    },
    timeTextActive: {
        ...material.captionWhite,
        textAlign: 'center',
        fontWeight: 'bold'
    },

    amountContainer: {
        flex: 1,
        flexDirection: 'row',
        // left: 16,
        // bottom: 16,
        alignSelf: 'center',
        paddingVertical: 16
    },
    amountButton: {
        borderRadius: 8,
        paddingHorizontal: 0,
        borderColor: 'transparent',
        backgroundColor: colors.white,
        borderRadius: 32,



        width: 40,
        height: 40,
        ...shadowStyle,
        justifyContent: 'center'
    },
    amount: {
        ...material.display2,
        textAlign: 'center',
        paddingHorizontal: 32,
        textAlignVertical: 'center',
        color: colors.green,
        fontWeight: 'bold'
    },
    removeButton: {
        right: 0,
    },
});

export default BookATable