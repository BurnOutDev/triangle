import React from 'react'
import { Text } from '@ui-kitten/components'
import { View } from 'react-native'
import { colors } from '../variables/colors'

const PriceTag = (props) => {
    let price = props.price
    
    if (props.count > 0) {
        price = props.price * props.count
    }

    return (
        <View style={{ flexDirection: 'row' }}>
            <Text category='p1' style={{ fontWeight: 'bold' }}>${price}</Text>
        </View>
    )
}

export default PriceTag