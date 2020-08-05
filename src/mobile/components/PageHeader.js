import React from 'react'
import { View, StatusBar } from 'react-native'
import { Button, Text } from '@ui-kitten/components'
import { colors } from '../variables/colors'
import { Back, Filter } from './Icons'
import PageHeaderContainer from './PageHeaderContainer'
import { useNavigation, useBackButton } from '@react-navigation/native'

const PageHeader = (props) => {
    let { goBack } = useNavigation()
    
    return (
        <PageHeaderContainer style={props.transparent && { backgroundColor: colors.transparent }}>
            <Button style={{ flex: 1 }} appearance='ghost' status='basic' icon={() => Back({ fill: props.transparent ? colors.green : colors.white })} onPress={goBack} />
            <Text style={{ flex: 10, textAlign: 'center', color: props.transparent ? colors.green : colors.white }} category='h5'>{props.title}</Text>
            <Button style={{ flex: 1 }} appearance='ghost' status='basic' icon={() => Filter({ fill: props.transparent ? colors.green : colors.white })} />
        </PageHeaderContainer>
    )
}

export default PageHeader