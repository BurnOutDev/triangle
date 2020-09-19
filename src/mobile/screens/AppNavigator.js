import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { HomeBottomNavigation } from './BottomTabNavigator';
import MostPopular from './Home/MostPopular';

import { Splash } from "./Splash";
import Authentication from "./Authentication/Authentication";
import { authorize, revoke } from "react-native-app-auth";
import openIdConfig from "../openIdConfig";
import Explore from "./Home/Explore";
import axios from 'axios';
import CategoryAll from "./Home/CategoryAll";
import Cuisine from "../screens/Home/Cuisine";
import { Icon } from "@ui-kitten/components";
import Account from "./Account/Index";
import { AuthContextProvider, AuthContext } from "../contexts/AuthProvider"
import { ReservationProvider, ReservationContext, ReservationStackScreen } from '../contexts/ReservationProvider'
import RestaurantDetails from "./Home/RestaurantDetails";

const Tabs = createBottomTabNavigator();

const SearchStack = createStackNavigator();

const SearchStackScreen = () => (
  <SearchStack.Navigator>
    <SearchStack.Screen name="Search" component={Search} />
    <SearchStack.Screen name="Search2" component={Search2} />
  </SearchStack.Navigator>
);

const ProfileStack = createStackNavigator();
const ProfileStackScreen = () => (
  <ProfileStack.Navigator>
    <ProfileStack.Screen name="Profile" component={Profile} />
  </ProfileStack.Navigator>
);

const StarIcon = (style) => (
  <Icon {...style} name='star' fill='#FFB700' />
);

const TabsScreen = (props) => (
  <Tabs.Navigator tabBar={props => <HomeBottomNavigation {...props} />}>
    <Tabs.Screen name='Home' component={Explore} />
    <Tabs.Screen name='CategoryAll' component={Account} />
    <Tabs.Screen name='Cuisine' component={Cuisine} />
    <Tabs.Screen name='Account' component={CategoryAll} />
  </Tabs.Navigator>
);

const RootStack = createStackNavigator();
const RootStackScreen = () => (
  <RootStack.Navigator headerMode="none">
    <RootStack.Screen name="Home" component={TabsScreen} />
    <RootStack.Screen name='RestaurantDetails' component={ReservationStackScreen} />
  </RootStack.Navigator>
)

export default () => (
  <AuthContextProvider>
    <RootStackScreen />
  </AuthContextProvider>
)