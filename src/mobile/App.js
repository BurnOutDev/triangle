import React from 'react';
import {StatusBar} from 'react-native';
import {ApplicationProvider, IconRegistry} from '@ui-kitten/components';
import {mapping, light as lightTheme} from '@eva-design/eva';
import {EvaIconsPack} from '@ui-kitten/eva-icons';
import AppNavigator from './screens/AppNavigator';

const App: () => React$Node = () => (
  <>
    <StatusBar
      backgroundColor="transparent"
      translucent
      barStyle="dark-content"
    />
    <IconRegistry icons={EvaIconsPack} />
    <ApplicationProvider mapping={mapping} theme={lightTheme}>
      <AppNavigator />
    </ApplicationProvider>
  </>
);

export default App;
