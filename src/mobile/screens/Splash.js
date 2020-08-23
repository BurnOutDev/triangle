import React from 'react'
import { View, ActivityIndicator } from 'react-native';

export const Splash = () => (
    <View style={{
      flex: 1,
      justifyContent: "center"
    }}>
      <ActivityIndicator color='green' size='large' />
    </View>
  );