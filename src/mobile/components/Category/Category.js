import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CategoryList from './CategoryList'

const Category = (props) => (
    <View style={{ margin: 15 }}>
        <Text category='h3'>{props.title}</Text>
        <CategoryList />
    </View>
)

export default Category