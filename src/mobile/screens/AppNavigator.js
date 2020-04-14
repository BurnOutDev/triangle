import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { BottomNavigation, BottomNavigationTab, Layout, Text, Icon } from '@ui-kitten/components';
import Explore from './Home/Explore';
import SignUp from './Authentication/SignUp';
import LogIn from './Authentication/LogIn';
import Authentication from './Authentication/Authentication';

const { Navigator, Screen } = createBottomTabNavigator();

const Icons = {
  Search: (style) => (
    <Icon {...style} width='16' height='16' fill='green' name='search' />
  ),
  Pin: (style) => (
    <Icon {...style} width='16' height='16' fill='green' name='pin-outline' />
  ),
  Heart: (style) => (
    <Icon {...style} width='16' height='16' fill='green' name='heart-outline' />
  ),
  Heart: (style) => (
    <Icon {...style} width='16' height='16' fill='green' name='person-outline' />
  )
}

const BottomTabBar = ({ navigation, state }) => (
  <BottomNavigation
    selectedIndex={state.index}
    onSelect={index => navigation.navigate(state.routeNames[index])}>
    <BottomNavigationTab icon={Icons.Search} />
    <BottomNavigationTab icon={Icons.Pin} />
    <BottomNavigationTab icon={Icons.Heart} />
    <BottomNavigationTab icon={Icons.Search} />
  </BottomNavigation>
);

const TabNavigator = () => (
  <Navigator tabBar={props => <BottomTabBar {...props} />}>
    <Screen name='Users' component={Explore} />
    <Screen name='Authentication' component={Authentication} />
    <Screen name='LogIn' component={LogIn} />
    <Screen name='SignUp' component={SignUp} />
  </Navigator>
);

const AppNavigator = () => (
  <NavigationContainer>
    <TabNavigator />
  </NavigationContainer>
);

export default AppNavigator