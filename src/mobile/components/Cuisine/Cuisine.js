import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CuisineList from './CuisineList'

const Cuisine = (props) => (
    <View style={{ margin: 15 }}>
        <Text category='h3'>Cuisine</Text>
        <CuisineList />
    </View>
)

export default Cuisine