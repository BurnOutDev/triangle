import React from 'react'
import { View, StatusBar } from 'react-native'
import { Button, Text } from '@ui-kitten/components'
import { colors } from '../variables/colors'
import { Back, Filter } from './Icons'
import PageHeaderContainer from './PageHeaderContainer'

const PageHeader = (props) => (
    <PageHeaderContainer>
        <Button style={{ flex: 1 }} appearance='ghost' status='basic' icon={() => Back({ fill: 'white' })} />
        <Text style={{ flex: 10, textAlign: 'center', color: colors.white }} category='h5'>{props.title}</Text>

        <Button style={{ flex: 1 }} appearance='ghost' status='basic' icon={() => Filter({ fill: 'white' })} />
    </PageHeaderContainer>
)

export default PageHeader