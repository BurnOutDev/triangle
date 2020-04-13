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
import SignIn from './screens/Authentication/SignIn';
import SignUp from './screens/Authentication/SignUp';
import AppNavigator from './screens/AppNavigator';
import Authentication from './screens/Authentication/Authentication';

const App: () => React$Node = () => {
  return (<>
    <IconRegistry icons={EvaIconsPack} />
    <ApplicationProvider mapping={mapping} theme={lightTheme}>
      <Authentication />
    </ApplicationProvider>
  </>);
};

export default App;
