import React from "react";
import { createStackNavigator } from "@react-navigation/stack";
import RestaurantDetails from "../screens/Home/RestaurantDetails";
import RestaurantMenu from "../screens/Home/RestaurantMenu";
import BookATable from "../screens/Home/BookATable";
import api from "../variables/api";
import axios from "../axios";
import log from "../log";
import { Splash } from "../screens/Screens";

// Create Context Object
export const ReservationContext = React.createContext({
    restaurantId: null,
    restaurant: null, 
    location: null, 
    menuItems: null,
    setMenuItems: null
});

const { Navigator, Screen } = createStackNavigator();

export const ReservationStackScreen = (props) => {
    const [restaurantId, setRestaurantId] = React.useState(props.route.params.restaurantId)
    const [restaurant, setResaurant] = React.useState(null)
    const [menuItems, setMenuItems] = React.useState(null)
    const [location, setLocation] = React.useState(null)

    React.useEffect(() => { if (restaurant == null) getData() }, [])

    const getData = async () => {
        const restaurantResponse = await axios.get(`Restaurant/Restaurant/${restaurantId}`)

        setResaurant(restaurantResponse.data)

        setLocation({
            latitude: parseFloat(restaurantResponse.data.addressLatitude),
            longitude: parseFloat(restaurantResponse.data.addressLongtitude),
            latitudeDelta: 0,
            longitudeDelta: 0
        })

        const menuItemsResponse = await axios.get(`Menu/GetMenuItems/${restaurantId}`)

        setMenuItems({
            ...menuItemsResponse.data,
            menuItems: menuItemsResponse.data.menuItems.map(x => ({
                ...x,
                visible: true
            }))
        })
    }

    return (restaurant ? <>
        <ReservationContext.Provider value={{ restaurantId, restaurant,setMenuItems, menuItems, location }}>
            <Navigator screenOptions={{ headerShown: false }}>
                <Screen name='RestaurantDetails' component={RestaurantDetails} />
                <Screen name='RestaurantMenu' component={RestaurantMenu} />
                <Screen name='BookATable' component={BookATable} />
            </Navigator>
        </ReservationContext.Provider>
    </> : <Splash />)
}