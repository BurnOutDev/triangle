import React from 'react'
import { View } from 'react-native'
import { Button, Text } from '@ui-kitten/components'
import { colors } from '../variables/colors'
import { Back } from './Icons'

const PageHeader = (props) => (
    <View style={{ backgroundColor: colors.green }}>
        <Button style={{ position: 'absolute', zIndex: 2 }}  appearance='ghost' status='basic' icon={Back} />
        <Text style={{ textAlign: 'center', color: colors.white }} category='h5'>Cuisine</Text>
    </View>
)

export default PageHeader