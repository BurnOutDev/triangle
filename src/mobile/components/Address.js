import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import { colors } from '../variables/colors'
import { ArrowRight, Location } from './Icons'

const Address = () => (
    <View style={{ padding: 15 }}>
        <Text category='h1'>Current</Text>
        <View style={{ flexDirection: 'row' }}>
            <Location />
            <Text style={{ color: colors.green, lineHeight: 18, paddingLeft: 4 }}>Unit 10, 2F, 123 York Street</Text>
            <ArrowRight />
        </View>
    </View>
)

export default Address