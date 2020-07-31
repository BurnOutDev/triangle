import React from 'react'
import Container from '../../components/Container';
import { View, ImageBackground, Linking, Dimensions } from 'react-native';
import { Text, StyleService, Icon, Button, Divider, ButtonGroup, TabBar, Tab } from '@ui-kitten/components';
import { Splash } from '../Screens';
import axios from '../../axios'
import { colors } from '../../variables/colors';
import { Back, Filter, ShareIcon, PhotoIcon, Heart } from '../../components/Icons';
import { TouchableOpacity, ScrollView } from 'react-native-gesture-handler';

import MapView, { MAP_TYPES, Marker, PROVIDER_DEFAULT, UrlTile } from 'react-native-maps';
import MenuHorizontalList from '../../components/Menu/MenuHorizontalList';
import { interpolate } from 'react-native-reanimated';
import { PinIcon, CalendarIcon, PersonIcon, ClockIcon } from '../../variables/Icons';
import { createStackNavigator } from '@react-navigation/stack';
import RestaurantMenu from './RestaurantMenu';

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

    const [date, setDate] = React.useState(nanSymbol)
    const [time, setTime] = React.useState(nanSymbol)
    const [persons, setPersons] = React.useState(nanSymbol)

    React.useEffect(() => { if (restaurant == null) setRestaurant(props.route.params.restaurant) }, []);

    const PictureHeader = (props) => (
        <View style={{ flexDirection: 'row', justifyContent: 'flex-start' }}>
            <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.white })} />
        </View>
    )

    const PictureFooter = (props) => (
        <View style={{ paddingHorizontal: 8 }}>
            <Text category='h2' style={{ color: colors.white, fontWeight: 'bold' }}>{restaurant.title}</Text>
        </View>
    )

    return (
        restaurant ? <View>
            <ImageBackground
                style={styles.itemHeader}
                source={{ uri: restaurant.image }}>
                <PictureHeader />

                <PictureFooter />
            </ImageBackground>

            <View style={styles.tabContainer}>
                <TouchableOpacity style={styles.tabButton2} onPress={() => setDate('13 Jan')}>
                    <CalendarIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, date === nanSymbol && { color: 'grey' }]}>{date}</Text>
                </TouchableOpacity>
                <Divider style={styles.divider} />
                <TouchableOpacity style={styles.tabButton2} onPress={() => setTime('4:00 pm')}>
                    <ClockIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, time === nanSymbol && { color: 'grey' }]}>{time}</Text>
                </TouchableOpacity>
                <Divider style={styles.divider} />
                <TouchableOpacity style={styles.tabButton2} onPress={() => setPersons(2)}>
                    <PersonIcon width={16} height={16} fill={colors.green} />
                    <Text style={[styles.barText, persons === nanSymbol && { color: 'grey' }]}>{persons}</Text>
                </TouchableOpacity>
            </View>

            {/* <TabBar
                selectedIndex={selectedIndex}
                onSelect={index => setSelectedIndex(index)}
                indicatorStyle={{ display: 'none' }}>
                <Tab icon={CalendarIcon} title='13 Jan' style={styles.tabButton} titleStyle={styles.titleStyle} />
                <Tab icon={ClockIcon} title='12:30' style={styles.tabButton} titleStyle={styles.titleStyle} />
                <Tab icon={PersonIcon} title='2' style={[styles.tabButton, styles.tabButtonLast]} titleStyle={styles.titleStyle} />
            </TabBar> */}
        </View> : <Splash />
    )
}

const styles = StyleService.create({
    itemHeader: {
        justifyContent: 'space-between',
        flexDirection: 'column',
        padding: 8
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
    bookButton: {
        backgroundColor: colors.green,
        position: 'absolute',
        alignSelf: 'center',
        bottom: 10,
        paddingHorizontal: 80,
        height: 50,
        borderRadius: 8,
        borderColor: 'none',

        ...shadowStyle
    },
    tabButton: {
        flexDirection: 'row',
        flex: 1,
        borderRightWidth: 1,
        borderRightColor: 'grey',
        justifyContent: 'flex-start',
        paddingHorizontal: 8
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
    }
});

export default BookATable