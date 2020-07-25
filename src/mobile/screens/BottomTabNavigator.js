import React from 'react';
import { BottomNavigationTab, Divider, BottomNavigation } from '@ui-kitten/components';
import { SearchIcon, PinIcon, HeartIcon, PersonIcon } from '../variables/Icons';
import { SafeAreaView } from 'react-native';
import { SafeAreaLayoutComponent } from '../components/SafeAreaLayout';

const HomeBottomNavigation = (props) => {

  const onSelect = (index) => {
    props.navigation.navigate(props.state.routeNames[index]);
  };

  return (
    <SafeAreaLayoutComponent insets='bottom'>
      <Divider/>
      <BottomNavigation
        appearance='noIndicator'
        selectedIndex={props.state.index}
        onSelect={onSelect}>
        <BottomNavigationTab
          title='Home'
          icon={SearchIcon}
        />
        <BottomNavigationTab
          title='Categories'
          icon={PinIcon}
        />
        <BottomNavigationTab
          title='Cuisine'
          icon={HeartIcon}
        />
         <BottomNavigationTab
          title='Profile'
          icon={PersonIcon}
        />
      </BottomNavigation>
    </SafeAreaLayoutComponent>
  );
};

export { HomeBottomNavigation };