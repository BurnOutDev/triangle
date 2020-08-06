import React, { useEffect } from 'react'
import Container from '../../components/Container'
import { material, systemWeights } from 'react-native-typography'
import { View, StatusBar } from 'react-native'
import { Avatar, Text, StyleService, Button, Divider } from '@ui-kitten/components'
import { avatar } from '../../variables/temp'
import { colors } from '../../variables/colors'
import { ArrowRight } from '../../components/Icons'
import { revoke } from 'react-native-app-auth'
import config from '../../openIdConfig'
import axios from '../../axios'
import api from '../../variables/api'
import { Splash } from '../Screens'

const Account = () => {
    const [data, setData] = React.useState(null)

    const getData = async () => {
        const response = await axios.get(api.customer.profile)

        setData(response.data)
    }

    useEffect(() => { if (data === null) getData() }, [])

    const NavItem = ({ title }) => (
        <>
            <Button
                appearance='ghost'
                textStyle={{ ...material.button, }}
                icon={() => <ArrowRight width={24} height={24} />}
                style={{ flexDirection: 'row-reverse', justifyContent: 'space-between' }}>
                {title}
            </Button>
            <Divider />
        </>
    )

    return (
        <Container style={styles.statusBarPadding}>
            {data ? <>
                <View style={{ flexDirection: 'row', paddingVertical: 16 }}>
                    <Avatar source={{ uri: data.avatar }} size='giant' style={{ alignSelf: 'center', width: 96, height: 96 }} />
                    <View style={{ flexDirection: 'column', paddingHorizontal: 8, alignSelf: 'center' }}>
                        <Text style={{ ...material.headline, ...systemWeights.bold }}>{data.firstName} {data.lastName}</Text>
                        <Text style={{ ...material.caption }}>{data.email}</Text>
                    </View>
                </View>
                <View style={styles.menuContainer}>
                    <NavItem title='Profile' />
                    <NavItem title='My Bookings' />
                    <NavItem title='Settings' />
                    <NavItem title='Help & Supports' />
                </View>
            </> : <Splash />}
        </Container>
    )
}

const styles = StyleService.create({
    statusBarPadding: {
        padding: 16,
        paddingTop: 32 + StatusBar.currentHeight,
    },
    menuContainer: {
        flexDirection: 'column'
    }
})

export { Account }