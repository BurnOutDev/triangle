import React from 'react'
import { View, StatusBar } from 'react-native'
import { Button, Text } from '@ui-kitten/components'
import { colors } from '../variables/colors'
import { Back, Filter as FilterIcon } from './Icons'
import PageHeaderContainer from './PageHeaderContainer'
import { useNavigation, useBackButton } from '@react-navigation/native'
import Filter from './Filter'

const PageHeader = ({ transparent, title, showFilter }) => {
    let { goBack } = useNavigation()

    return (
        <>
            {title && <>
                <PageHeaderContainer style={transparent && { backgroundColor: colors.transparent }}>
                    <Button style={{ flex: 1 }} appearance='ghost' status='basic' icon={() => Back({ fill: transparent ? colors.green : colors.white })} onPress={goBack} />
                    <Text style={{ flex: 10, textAlign: 'center', color: transparent ? colors.green : colors.white }} category='h5'>{title}</Text>
                    <Button style={{ flex: 1 }} appearance='ghost' status='basic' icon={() => FilterIcon({ fill: transparent ? colors.green : colors.white })} />
                </PageHeaderContainer>
            </>}
            {showFilter && <Filter statusBarPadding={!title} />}
        </>
    )
}

export default PageHeader