import React from 'react'
import Container from '../../components/Container';
import { View, ImageBackground, Linking, Dimensions } from 'react-native';
import { Text, StyleService, Icon, Button, Divider, ButtonGroup, TabBar, Tab, Modal, Layout } from '@ui-kitten/components';
import { Splash } from '../Screens';
import axios from '../../axios'
import { colors } from '../../variables/colors';
import { Back, Filter, ShareIcon, PhotoIcon, Heart, PlusIcon, MinusIcon, CheckIcon } from '../../components/Icons';
import { TouchableOpacity, ScrollView } from 'react-native-gesture-handler';

import MapView, { MAP_TYPES, Marker, PROVIDER_DEFAULT, UrlTile } from 'react-native-maps';
import MenuHorizontalList from '../../components/Menu/MenuHorizontalList';
import Animated, { interpolate } from 'react-native-reanimated';
import { PinIcon, CalendarIcon, PersonIcon, ClockIcon } from '../../components/Icons';
import { createStackNavigator } from '@react-navigation/stack';
import RestaurantMenu from './RestaurantMenu';
import moment from 'moment'

import DateTimePicker from '@react-native-community/datetimepicker';
import { material, systemWeights } from 'react-native-typography';
import SingleButton from '../../components/SingleButton';

import { Calendar } from 'react-native-calendars'
import api from '../../variables/api';

const formats = {
    month: 'MMMM',
    barDate: 'DD MMM',
    default: 'YYYY-MM-DD',
    hour: 'HH:mm'
}

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
    const [menuItems, setMenuItems] = React.useState(null)
    const [selectedIndex, setSelectedIndex] = React.useState(0);

    const [dateIsSelected, setDateIsSelected] = React.useState(false)
    const [timeIsSelected, setTimesIsSelected] = React.useState(false)

    const [date, setDate] = React.useState({ value: new Date(), selected: false })
    const [selectedTime, setSelectedTime] = React.useState({ value: null, selected: false })
    const [currentStep, setCurrentStep] = React.useState(1)

    const [times, setTimes] = React.useState([
        { category: 'Lunch', times: [['11:30', '12:00', '12:30', '13:00']] },
        { category: 'Dinner', times: [['17:30', '18:00', '18:30', '19:00'], ['19:30', '20:00', '20:30', '21:00']] },
    ])

    const [buttonVisible, setButtonVisible] = React.useState(false)

    const [partySize, setPartySize] = React.useState({
        adults: 0,
        children: 0,
        selected: false
    })

    const [visible, setVisible] = React.useState(false);

    React.useEffect(() => { if (restaurant == null) setRestaurant(props.route.params.restaurant) }, []);
    React.useEffect(() => { if (menuItems == null) setMenuItems(props.route.params.menuItems) }, []);

    const PictureHeader = (props) => (
        <View style={{ flexDirection: 'row', justifyContent: 'flex-start' }}>
            <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.white })} />
        </View>
    )

    const SelectDate = (nextDate) => {
        setDate(moment(nextDate.timestamp))
        setDateIsSelected(true)
        setButtonVisible(true)
    }

    const PictureFooter = (props) => (
        <View style={{ paddingHorizontal: 8 }}>
            <Text category='h2' style={{ ...material.display2White, fontWeight: 'bold', color: colors.white }}>{restaurant.title}</Text>
        </View>
    )

    const Continue = async () => {
        if (dateIsSelected && timeIsSelected && partySize.adults > 0) {
            let response = await axios.post(api.reservation.reserve, {
                restaurantId: restaurant.restaurantId,
                dateAndTime: date,
                partySizeChildren: partySize.children,
                partySizeAdults: partySize.adults,
                menuItems: menuItems.map(i => ({
                    menuItemId: i.menuItemId,
                    quantity: i.count
                }))
            })

            debugger

            console.log(response.data)

            setVisible(true)
        } else {

            setCurrentStep(currentStep + 1)
        }

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

    const RenderDay = (state) => (
        moment(state.date.timestamp).format(formats.default) === moment(date).format(formats.default) ? (
            <View style={styles.calendarDayActive}>
                <Text style={{ textAlign: 'center', color: colors.white }}>{state.date.day}</Text>
            </View>
        ) : <View style={styles.calendarDay} onTouchStart={() => SelectDate(state.date)}>
                <Text style={{ textAlign: 'center', color: colors.black }}>{state.date.day}</Text>
            </View>)

    const RenderHeader = (date) => <Text category='h6'>{moment(date.toDateString()).format(formats.month)}</Text>

    const StepBack = (step) => {
        return false

        if (dateIsSelected && timeIsSelected && partySize.adults > 0) {
            setCurrentStep(step)
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
                <TouchableOpacity style={styles.tabButton2} onPress={() => StepBack(1)}>
                    <CalendarIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, !dateIsSelected && { color: 'grey' }]}>{dateIsSelected ? moment(date).format(formats.barDate) : nanSymbol}</Text>
                </TouchableOpacity>
                <Divider style={styles.divider} />
                <TouchableOpacity style={styles.tabButton2} onPress={() => StepBack(2)}>
                    <ClockIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, !timeIsSelected && { color: 'grey' }]}>{timeIsSelected ? moment(date).format(formats.hour) : nanSymbol}</Text>
                </TouchableOpacity>
                <Divider style={styles.divider} />
                <TouchableOpacity style={styles.tabButton2} onPress={() => StepBack(3)}>
                    <PersonIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, partySize.adults === 0 && { color: 'grey' }]}>{partySize.adults > 0 ? partySize.adults + partySize.children : nanSymbol}</Text>
                </TouchableOpacity>
            </View>

            <ScrollView style={{ paddingTop: 24 }}>
                <Text category='h5' style={{ textAlign: 'center', ...material.title }}>Book a table</Text>
                {currentStep === 1 && ( //{ display: 'flex', flexDirection: 'column', justifyContent: 'space-between' 
                    <View>
                        <Calendar
                            onDayPress={SelectDate}
                            monthFormat='MMMM'
                            renderArrow={(direction) => (<Icon name={direction === 'left' ? 'arrow-back-outline' : 'arrow-forward-outline'} height={24} width={24} fill={colors.grey} />)}
                            renderHeader={RenderHeader}
                            current={moment(date).format(formats.default)}
                            style={styles.calendar}
                            markedDates={{
                                [moment(date).format(formats.default)]: {
                                    selected: true, customStyles: {
                                        container: {
                                            backgroundColor: colors.active,
                                            ...shadowStyle,
                                            borderWidth: 2,
                                            borderColor: colors.white,
                                            margin: 0,
                                            padding: 0
                                        },
                                        text: {
                                            textAlign: 'center',
                                            textAlignVertical: 'center',
                                            padding: 0,
                                            margin: 0,
                                            marginTop: 2,
                                        },
                                    }
                                }
                            }}
                            markingType='custom'
                            theme={{
                                todayTextColor: colors.caldendarDefaultDayColor
                            }}
                        />
                    </View>)}
                {currentStep === 2 && (
                    <View>
                        {times.map(_ => (
                            <View style={{ paddingHorizontal: 32 }}>
                                <Text style={{ marginVertical: 16, textAlign: 'center', ...material.subheading }}>{_.category}</Text>
                                {_.times.map(times => (
                                    <View style={{ flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'space-between' }}>
                                        {times.map((time, index) => (
                                            <TouchableOpacity key={index}
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
            <Modal
                backdropStyle={styles.backdrop}
                visible={visible}
                onBackdropPress={() => {
                    props.navigation.navigate('RestaurantDetails')
                    setVisible(false)
                }}>
                <Layout
                    level='3'
                    style={styles.modalContainer}>

                    <View style={{ backgroundColor: colors.active, borderRadius: 64 }}>
                        <CheckIcon height={64} width={64} fill={colors.white} />
                    </View>

                    <Text category='h3' style={{ fontWeight: 'bold', textAlign: 'center', ...systemWeights.semibold, paddingVertical: 16 }}>Your booking has been confirmed</Text>
                    <Text style={{ textAlign: 'center', paddingHorizontal: 32, ...material.caption }}>You can manage your booking in "Manage Booking" section.</Text>
                    <View style={{ width: '100%', paddingVertical: 24 }}>
                        <Divider style={{ width: '100%', backgroundColor: colors.lightGrey, marginBottom: 16 }} />
                        <Text style={{ ...material.headline, ...systemWeights.semibold, color: colors.green, textAlign: 'center', paddingBottom: 8 }}>{props.route.params.restaurant.title}</Text>
                        <Text style={{ ...material.body1, color: colors.green, textAlign: 'center', paddingBottom: 8 }}>{moment(date).format('HH:mm - DD MMM, YYYY')} - 2 persons</Text>
                        <Text style={{ ...material.body1, color: colors.green, textAlign: 'center' }}>Booking No. Ghf349da</Text>
                        <Divider style={{ width: '100%', backgroundColor: colors.lightGrey, marginTop: 16 }} />
                    </View>
                    <SingleButton text='Return to restaurant' style={{ paddingHorizontal: 60 }} />
                </Layout>
            </Modal>
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
        borderRightColor: colors.lightGrey,
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
    calendarDay: {
        backgroundColor: colors.transparent,
        width: 32,
        height: 32,
        borderRadius: 32,
        justifyContent: 'center',
    },
    calendarDayActive: {
        backgroundColor: colors.active,
        width: 32,
        height: 32,
        borderRadius: 32,
        justifyContent: 'center',
        borderWidth: 3,
        borderColor: colors.white,
        ...shadowStyle,
    },
    modalContainer: {
        alignItems: 'center',
        width: Dimensions.get('window').width - 32,
        borderRadius: 32,
        padding: 24,
        backgroundColor: colors.white
    },
    backdrop: {
        backgroundColor: 'rgba(0, 0, 0, 0.5)',
    },
});

export default BookATable