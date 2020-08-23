import React from 'react'
import Container from '../../components/Container';
import { View, ImageBackground, Linking, Dimensions, StatusBar } from 'react-native';
import { Text, StyleService, Icon, Button, Divider } from '@ui-kitten/components';
import { Splash } from '../Splash';
import axios from '../../axios'
import { colors } from '../../variables/colors';
import { Back, Filter, ShareIcon, PhotoIcon, Heart } from '../../components/Icons';
import { TouchableOpacity, ScrollView } from 'react-native-gesture-handler';

import MapView, { MAP_TYPES, Marker, PROVIDER_DEFAULT, UrlTile } from 'react-native-maps';
import MenuHorizontalList from '../../components/Menu/MenuHorizontalList';
import { interpolate } from 'react-native-reanimated';
import { PinIcon } from '../../components/Icons';
import { createStackNavigator } from '@react-navigation/stack';
import RestaurantMenu from './RestaurantMenu';
import BookATable from './BookATable';
import Reviews from '../../components/Reviews';
import { ReservationContext } from '../../contexts/ReservationProvider';

const { width, height } = Dimensions.get('window');

const { Navigator, Screen } = createStackNavigator();

const StarIcon = (style) => (
    <Icon {...style} name='star' fill='#FFB700' />
);

const RestaurantDetails = (props) => {

    const { restaurantId, restaurant, location, menuItems } = React.useContext(ReservationContext)

    const PictureHeader = (props) => (
        <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
            <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.white })} />
            <Button appearance='ghost' status='basic' icon={() => ShareIcon({ fill: colors.white })} />
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

    const DetailText = ({ name, link, value }) => (
        <View style={styles.detailTexts}>
            <Text appearance='hint'>{name}</Text>
            {link ? <TouchableOpacity onPress={() => Linking.openURL(link)}><Text style={{ color: colors.green }}>{value}</Text></TouchableOpacity> : <Text>{value}</Text>}
        </View>
    )

    const navigateToMenu = () => {
        props.navigation.navigate('RestaurantMenu')
    }

    return (
        restaurant ? <View>
            <StatusBar hidden />
            <ScrollView style={{ backgroundColor: colors.white }}>
                <ImageBackground
                    style={styles.itemHeader}
                    source={{ uri: restaurant.image }}
                >
                    <PictureHeader />

                    <PictureFooter />
                </ImageBackground>

                <View style={{ padding: 8 }}>
                    <Text category='h4' style={{ color: colors.green, fontWeight: 'bold' }}>{restaurant.title}</Text>

                    <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
                        <View>
                            <Text category='s1' appearance='hint' style={{ lineHeight: 24 }}>{restaurant.address}</Text>
                            <Text category='s1' appearance='hint' style={{ lineHeight: 24 }}>{restaurant.cuisine} • $$</Text>
                        </View>
                        <View>
                            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                                <StarIcon width={24} height={24} />
                                <Text category='h2' style={{ fontWeight: 'bold', paddingLeft: 4, color: colors.gold }}>4.9</Text>
                            </View>
                            <Text category='s1' appearance='hint'>{`${restaurant.reviewsCount} reviews`}</Text>
                        </View>
                    </View>
                </View>

                {location && <MapView
                    provider={PROVIDER_DEFAULT}
                    style={styles.map}
                    scrollEnabled={true}
                    zoomEnabled={true}
                    pitchEnabled={true}
                    rotateEnabled={true}
                    initialRegion={location}>
                    <Marker coordinate={location}>
                        <Button icon={PinIcon} style={{ backgroundColor: colors.green, borderRadius: 32, paddingHorizontal: 0 }}></Button>
                    </Marker>
                </MapView>}

                <View style={{ padding: 8 }}>
                    <DetailText name='Average Cost' value='$20 - $50' />
                    <DetailText name='Hours' value='Open now 7 am - 6 pm' />
                    <DetailText color={colors.green} name='Phone' value='(+995) 568 144 133' link='tel:568144133' />
                    <DetailText color={colors.green} name='Website' value={restaurant.website} link={restaurant.website} />
                </View>

                <View style={{ paddingVertical: 8, paddingHorizontal: 16 }}>
                    <View style={{ flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' }}>
                        <Text category='h4' style={{ fontWeight: 'bold' }}>Menu</Text>
                        <TouchableOpacity onPress={navigateToMenu}><Text style={{ color: colors.green }}>View all</Text></TouchableOpacity>
                    </View>
                    {menuItems ? <MenuHorizontalList menuItems={menuItems.menuItems} /> : <Splash />}
                </View>
                <Reviews />
                <Divider style={{ backgroundColor: colors.transparent, paddingBottom: styles.bookButton.height + styles.bookButton.bottom * 2 }} />
            </ScrollView>
            <Button onPress={navigateToMenu} style={styles.bookButton} size='large' textStyle={{ fontWeight: 'normal' }}>Book a table</Button>
        </View> : <Splash />
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
        borderColor: 'transparent',

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

export default RestaurantDetails