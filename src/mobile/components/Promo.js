import React from 'react'
import { View } from 'react-native'
import { Text } from '@ui-kitten/components'
import { colors } from '../variables/colors'

const Promo = () => (
    <View style={{ marginLeft: 15, marginRight: 15, backgroundColor: colors.green, borderRadius: 10 }}>
        <Text category='h4' style={{ color: 'white', padding: 30, textAlign: 'center' }}>Get 50% Off Food Discount</Text>
    </View>
)

export default Promo