import React from 'react';
import { BottomNavigationTab, Divider, BottomNavigation } from '@ui-kitten/components';
import { ColorPaletteIcon, LayoutIcon, ListIcon, StarOutlineIcon } from '../variables/Icons';
import { SafeAreaView } from 'react-native-safe-area-context';
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
          icon={LayoutIcon}
        />
        <BottomNavigationTab
          title='Categories'
          icon={StarOutlineIcon}
        />
        <BottomNavigationTab
          title='Cuisine'
          icon={ListIcon}
        />
      </BottomNavigation>
    </SafeAreaLayoutComponent>
  );
};

export { HomeBottomNavigation };