import React from "react";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { createStackNavigator } from "@react-navigation/stack";
import { Icon } from "@ui-kitten/components";
import { AuthContextProvider } from "../contexts/AuthProvider";
import { ReservationStackScreen } from '../contexts/ReservationProvider';
import Cuisine from "../screens/Home/Cuisine";
import Account from "./Account/Index";
import { HomeBottomNavigation } from './BottomTabNavigator';
import CategoryAll from "./Home/CategoryAll";
import Explore from "./Home/Explore";

const Tabs = createBottomTabNavigator();
const TabsNavigator = (props) => (
  <Tabs.Navigator tabBar={props => <HomeBottomNavigation {...props} />}>
    <Tabs.Screen name='Home' component={Explore} />
    <Tabs.Screen name='CategoryAll' component={Account} />
    <Tabs.Screen name='Cuisine' component={Cuisine} />
    <Tabs.Screen name='Account' component={CategoryAll} />
  </Tabs.Navigator>
);

const RootStack = createStackNavigator();
const RootStackNavigator = () => (
  <RootStack.Navigator headerMode="none">
    <RootStack.Screen name="Home" component={TabsNavigator} />
    <RootStack.Screen name='RestaurantDetails' component={ReservationStackScreen} />
  </RootStack.Navigator>
)

export default () => (
  <AuthContextProvider>
    <RootStackNavigator />
  </AuthContextProvider>
)