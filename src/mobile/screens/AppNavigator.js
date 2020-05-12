import React from 'react';
import { NavigationContainer,  } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createStackNavigator } from '@react-navigation/stack';
import { BottomNavigation, BottomNavigationTab, Layout, Text, Icon } from '@ui-kitten/components';
import Explore from './Home/Explore';
import SignUp from './Authentication/SignUp';
import LogIn from './Authentication/LogIn';
import Authentication from './Authentication/Authentication';
import Cuisine from './Home/Cuisine';
import { Search, Pin, Heart, Person } from '../components/Icons';
import Location from './Home/Location';
import CategoryAll from './Home/CategoryAll';

const { Navigator, Screen } = createBottomTabNavigator();
const Stack = createStackNavigator();

const BottomTabBar = ({ navigation, state }) => (
  <BottomNavigation
    selectedIndex={state.index}
    onSelect={index => navigation.navigate(state.routeNames[index])}>
    <BottomNavigationTab icon={Search} />
    <BottomNavigationTab icon={Pin} />
    <BottomNavigationTab icon={Heart} />
    <BottomNavigationTab icon={Person} />
  </BottomNavigation>
);

const TabNavigator = () => (
  <Navigator tabBar={props => <BottomTabBar {...props} />}>
    <Screen name='Users' component={CategoryAll} />
    <Screen name='Authentication' component={Explore} />
    <Screen name='LogIn' component={Cuisine} />
    <Screen name='SignUp' component={SignUp} />
  </Navigator>
);

const AuthNavigator = () => (
  <Stack.Navigator>
    <Stack.Screen name='Users'  component={Authentication} />
  </Stack.Navigator>
)

const AppNavigator = () => (
  <NavigationContainer>
    <AuthNavigator />
    <TabNavigator />
  </NavigationContainer>
);

export default AppNavigator