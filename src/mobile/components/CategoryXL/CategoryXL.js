import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import CategoryXLList from './CategoryXLList'

const CategoryXL = (props) => (
    <View style={{ margin: 15 }}>
        <Text category='h3'>{props.title}</Text>
        <CategoryXLList />
    </View>
)

export default CategoryXL