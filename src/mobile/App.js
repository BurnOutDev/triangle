/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow strict-local
 */

import React from 'react';
import {
  SafeAreaView,
  StyleSheet,
  ScrollView,
  View,
  Text,
  StatusBar,
} from 'react-native';
import { ApplicationProvider, IconRegistry } from '@ui-kitten/components';
import { mapping, light as lightTheme } from '@eva-design/eva';
import { EvaIconsPack } from '@ui-kitten/eva-icons';
import LogIn from './screens/Authentication/LogIn';
import AppNavigator from './screens/AppNavigator';
import Authentication from './screens/Authentication/Authentication';
import SignUp from './screens/Authentication/SignUp';
import IntroLayout from './screens/Intro/IntroLayout';
import Explore from './screens/Home/Explore';

const App: () => React$Node = () => {
  return (<>
    <IconRegistry icons={EvaIconsPack} />
    <ApplicationProvider mapping={mapping} theme={lightTheme}>
      <Explore />
    </ApplicationProvider>
  </>);
};

export default App;
