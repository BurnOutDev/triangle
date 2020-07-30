import React from 'react'
import Container from '../../components/Container';
import { View, ImageBackground, Linking, Dimensions } from 'react-native';
import { Text, StyleService, Icon, Button, Divider } from '@ui-kitten/components';
import { Splash } from '../Screens';
import axios from '../../axios'
import { colors } from '../../variables/colors';
import { Back, Filter, ShareIcon, PhotoIcon, Heart } from '../../components/Icons';
import { TouchableOpacity, ScrollView } from 'react-native-gesture-handler';

import MapView, { MAP_TYPES, Marker, PROVIDER_DEFAULT, UrlTile } from 'react-native-maps';
import MenuHorizontalList from '../../components/Menu/MenuHorizontalList';
import { interpolate } from 'react-native-reanimated';
import { PinIcon } from '../../variables/Icons';
import { createStackNavigator } from '@react-navigation/stack';
import RestaurantMenu from './RestaurantMenu';

const { Navigator, Screen } = createStackNavigator()

const BookATable = (props) => {
    const [restaurant, setRestaurant] = React.useState(null)

    React.useEffect(() => { if (restaurant == null) setRestaurant(props.route.params.restaurant) }, []);

    const PictureHeader = (props) => (
        <View style={{ flexDirection: 'row', justifyContent: 'flex-start' }}>
            <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.white })} />
        </View>
    )

    const PictureFooter = (props) => (
        <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
            <View style={{ flexDirection: 'row', top: 20 }}>
                <PhotoIcon fill={colors.white} width='16' height='16' />
                <Text style={{ color: colors.white }}>168</Text>
            </View>

            <Button
                style={styles.iconButton}
                size='small'
                icon={Heart}
                appearance='ghost'
            />
        </View>
    )

    return (
        restaurant ? <ImageBackground
            style={styles.itemHeader}
            source={{ uri: restaurant.image }}>
            <PictureHeader />

            <PictureFooter />
        </ImageBackground> : <Splash />
    )
}

const styles = StyleService.create({
    itemHeader: {
        justifyContent: 'space-between',
        flexDirection: 'column',
        padding: 8,
        height: 250
    },
    iconButton: {
        paddingHorizontal: 0,
        backgroundColor: colors.white,
        width: 16,
        borderRadius: 16,
        top: 20,

        shadowColor: "#000",
        shadowOffset: {
            width: 0,
            height: 2,
        },
        shadowOpacity: 0.25,
        shadowRadius: 3.84,

        elevation: 5,

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

        shadowColor: "#000",
        shadowOffset: {
            width: 0,
            height: 2,
        },
        shadowOpacity: 0.25,
        shadowRadius: 3.84,

        elevation: 5,
    }
});

export default BookATable