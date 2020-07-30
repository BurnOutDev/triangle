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

const { width, height } = Dimensions.get('window');

const { Navigator, Screen } = createStackNavigator();

const ASPECT_RATIO = width / height; //,
const LATITUDE = 41.7057911;
const LONGITUDE = 44.7870449;
const LATITUDE_DELTA = 0.0922;
const LONGITUDE_DELTA = LATITUDE_DELTA * ASPECT_RATIO;

const StarIcon = (style) => (
    <Icon {...style} name='star' fill='#FFB700' />
);

const RestaurantDetails = (props) => {

    const [restaurant, setResaurant] = React.useState(null)
    const [menuItems, setMenuItems] = React.useState(null)
    const [location, setLocation] = React.useState(null)

    React.useEffect(() => { if (restaurant == null) getData() }, []);

    const getData = async () => {
        const restaurantId = 1

        const restaurantResponse = await axios.get(`Restaurant/Restaurant/${restaurantId}`)

        setResaurant(restaurantResponse.data)

        setLocation({
            latitude: parseFloat(restaurantResponse.data.addressLatitude),
            longitude: parseFloat(restaurantResponse.data.addressLongtitude),
            latitudeDelta: 0,
            longitudeDelta: 0
        })

        const menuItemsResponse = await axios.get(`Menu/GetMenuItems/${restaurantId}`)

        setMenuItems(menuItemsResponse.data)
    }

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

    return (
        restaurant ? <View>
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
                    <DetailText color={colors.green} name='Website' value={restaurant.website} link='http://lolitarestaurant.ge' />
                </View>

                <View style={{ paddingVertical: 8, paddingHorizontal: 16 }}>
                    <View style={{ flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center' }}>
                        <Text category='h4' style={{ fontWeight: 'bold' }}>Menu</Text>
                        <TouchableOpacity onPress={() => props.navigation.navigate('RestaurantMenu', { restaurantId: restaurant.restaurantId })}><Text style={{ color: colors.green }}>View all</Text></TouchableOpacity>
                    </View>
                    {menuItems ? <MenuHorizontalList menuItems={menuItems.menuItems} /> : <Splash />}
                </View>
                <Divider style={{ backgroundColor: colors.transparent, paddingBottom: styles.bookButton.height + styles.bookButton.bottom * 2 }} />
            </ScrollView>
            <Button style={styles.bookButton} size='large' textStyle={{ fontWeight: 'normal' }}>Book a table</Button>
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

export default (props) => (
    <Navigator>
        <Screen name='RestaurantDetails' component={RestaurantDetails} options={{ headerShown: false }} />
        <Screen name='RestaurantMenu' component={RestaurantMenu} options={{ headerShown: false }} />
    </Navigator>
)