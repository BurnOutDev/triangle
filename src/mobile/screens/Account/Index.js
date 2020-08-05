import React from 'react'
import Container from '../../components/Container'
import { material, systemWeights } from 'react-native-typography'
import { View, StatusBar } from 'react-native'
import { Avatar, Text, StyleService, Button, Divider } from '@ui-kitten/components'
import { avatar } from '../../variables/temp'
import { colors } from '../../variables/colors'
import { ArrowRight } from '../../components/Icons'
import { revoke } from 'react-native-app-auth'
import config from '../../openIdConfig'

const Account = () => {

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
            <View style={{ flexDirection: 'row', paddingVertical: 16 }}>
                <Avatar source={{ uri: avatar }} size='giant' style={{ alignSelf: 'center', width: 96, height: 96 }} />
                <View style={{ flexDirection: 'column', paddingHorizontal: 8, alignSelf: 'center' }}>
                    <Text style={{ ...material.headline, ...systemWeights.bold }}>Katie Robinson</Text>
                    <Text style={{ ...material.caption }}>hello@gmail.com</Text>
                </View>
            </View>
            <View style={styles.menuContainer}>
                <NavItem title='Profile' />
                <NavItem title='My Bookings' />
                <NavItem title='Settings' />
                <NavItem title='Help & Supports' />
            </View>
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