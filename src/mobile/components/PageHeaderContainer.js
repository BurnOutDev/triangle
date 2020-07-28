import React from 'react'
import { View, StatusBar } from 'react-native'
import { Button, Text } from '@ui-kitten/components'
import { colors } from '../variables/colors'
import { Back, Filter } from './Icons'

const PageHeaderContainer = (props) => (
    <View style={[{ backgroundColor: colors.green, flexDirection: 'row', paddingTop: StatusBar.currentHeight, alignItems: 'center' }, props.style]}>
        {props.children}
    </View>
)

export default PageHeaderContainer