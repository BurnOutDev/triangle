import React from 'react'
import { Text } from '@ui-kitten/components'
import { View } from 'react-native'
import { colors } from '../variables/colors'

const PriceTag = ({ price, count }) => {
    let priceCalculated = price

    if (count > 0) {
        priceCalculated = price * count
    }

    return (
        <View style={{ flexDirection: 'row' }}>
            <Text category='p1' style={{ fontWeight: 'bold' }}>${price}</Text>
        </View>
    )
}

export default PriceTag