import React from "react";
import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { createDrawerNavigator } from "@react-navigation/drawer";
import AsyncStorage from '@react-native-community/async-storage';
import { HomeBottomNavigation } from './BottomTabNavigator';
import MostPopular from './Home/MostPopular';

import { AuthContext } from "./context";

import {
  SignIn,
  CreateAccount,
  Search,
  Home,
  Details,
  Search2,
  Profile,
  Splash
} from "./Screens";
import Authentication from "./Authentication/Authentication";
import { authorize, revoke } from "react-native-app-auth";
import openIdConfig from "../openIdConfig";
import Explore from "./Home/Explore";
import axios from 'axios';
import CategoryAll from "./Home/CategoryAll";
import Cuisine from "../screens/Home/Cuisine";
import { Icon } from "@ui-kitten/components";
import RestaurantMenu from "./Home/RestaurantMenu";
import RestaurantDetails from "./Home/RestaurantDetails";
import BookATable from "./Home/BookATable";
import { Account } from "./Account/Index";
import api from "../variables/api";

const AuthStack = createStackNavigator();
const AuthStackScreen = () => (
  <AuthStack.Navigator>
    <AuthStack.Screen
      name="Authentication"
      component={Authentication}
      options={{ headerShown: false }}
    />
    <AuthStack.Screen
      name="CreateAccount"
      component={CreateAccount}
      options={{ title: "Create Account" }}
    />
  </AuthStack.Navigator>
);

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
    <Tabs.Screen name='CategoryAll' component={RestaurantDetails} />
    <Tabs.Screen name='Cuisine' component={Cuisine} />
    <Tabs.Screen name='Account' component={Account} />
  </Tabs.Navigator>
);

const Drawer = createStackNavigator();
const DrawerScreen = () => (
  <Drawer.Navigator screenOptions={{ headerShown: false }}>
    <Drawer.Screen name="Home" component={TabsScreen} />
    <Drawer.Screen name='RestaurantMenu' component={RestaurantMenu} />
    <Drawer.Screen name='BookATable' component={BookATable} />
  </Drawer.Navigator>
);

const RootStack = createStackNavigator();
const RootStackScreen = ({ userToken }) => (
  <RootStack.Navigator headerMode="none">
    {userToken ? (
      <RootStack.Screen
        name="App"
        component={DrawerScreen}
        options={{
          animationEnabled: false,

        }}
      />
    ) : (
        <RootStack.Screen
          name="Auth"
          component={AuthStackScreen}
          options={{
            animationEnabled: false
          }}
        />
      )}
  </RootStack.Navigator>
);

export default () => {
  const [isLoading, setIsLoading] = React.useState(true);
  const [userToken, setUserToken] = React.useState(null);

  const authContext = React.useMemo(() => {
    return {
      signIn: async () => {
        setIsLoading(true);

        AsyncStorage.getItem('token', (err, res) => {

          if (res) {
            setUserToken(res)
            setIsLoading(false)
          } else {
            authorize(openIdConfig).then(result => {
              AsyncStorage.setItem('token', result.accessToken)
              setUserToken(result.accessToken)
              setIsLoading(false)
            })
          }
        })

      },
      signUp: () => {
        setIsLoading(false);
        setUserToken("asdf");
      },
      signOut: () => {
        setIsLoading(false);
        setUserToken(null);

        revoke(openIdConfig, { tokenToRevoke: userToken })
      },
      getToken: () => userToken
    };
  }, []);

  React.useEffect(() => {
    setTimeout(() => {
      setIsLoading(false);
    }, 1000);
  }, []);

  if (isLoading) {
    return <Splash />;
  }

  return (
    <AuthContext.Provider value={authContext}>
      <NavigationContainer>
        <RootStackScreen userToken={userToken} />
      </NavigationContainer>
    </AuthContext.Provider>
  );
};
