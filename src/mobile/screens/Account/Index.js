import React, { useEffect } from 'react'
import Container from '../../components/Container'
import { material, systemWeights } from 'react-native-typography'
import { View, StatusBar, ImageBackground } from 'react-native'
import { Avatar, Text, StyleService, Button, Divider, ListItem, Spinner } from '@ui-kitten/components'
import { avatar } from '../../variables/temp'
import { colors } from '../../variables/colors'
import { ArrowRight, Back, Filter } from '../../components/Icons'
import { revoke } from 'react-native-app-auth'
import config from '../../openIdConfig'
import axios from '../../axios'
import api from '../../variables/api'
import { Splash } from '../Screens'
import { createStackNavigator } from '@react-navigation/stack'
import PageHeaderContainer from '../../components/PageHeaderContainer'
import { useNavigation } from '@react-navigation/native'
import { ScrollView } from 'react-native-gesture-handler'
import moment from 'moment'
import PriceTag from '../../components/PriceTag'
import PageHeader from '../../components/PageHeader'

const Account = () => {
    const [data, setData] = React.useState(null)

    const getData = async () => {
        const response = await axios.get(api.customer.profile)

        setData(response.data)
    }
    const { navigate } = useNavigation()
    useEffect(() => { if (data === null) getData() }, [])

    const NavItem = ({ title, screen }) => (
        <>
            <Button
                appearance='ghost'
                textStyle={{ ...material.button, }}
                icon={() => <ArrowRight width={24} height={24} />}
                style={{ flexDirection: 'row-reverse', justifyContent: 'space-between' }}
                onPress={() => navigate(screen)}>
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
                    <NavItem title='My Bookings' screen='AccountBookings' />
                    <NavItem title='Settings' />
                    <NavItem title='Help & Supports' />
                </View>
            </> : <Splash />}
        </Container>
    )
}

const styles = StyleService.create({
    statusBarPadding: {
        paddingHorizontal: 16,
        paddingTop: 32 + StatusBar.currentHeight,
    },
    menuContainer: {
        flexDirection: 'column'
    },
    modalHeaderImage: {
        width: '100%',
        height: 192,
        borderTopLeftRadius: 32,
        borderTopRightRadius: 32
    },
    subheader: {
        ...material.caption
    },
    menuItemQuantity: {
        height: 32,
        width: 32,
        borderRadius: 24,
        borderWidth: 1,
        textAlign: 'center',
        textAlignVertical: 'center',
        ...material.caption,
        borderColor: colors.lightGrey,
        marginRight: 4
    }
})

const AccountBookings = (props) => {
    const [data, setData] = React.useState(null)

    const { navigate } = useNavigation()

    React.useEffect(() => { if (data == null) getData() }, [])

    const getData = async () => {
        const response = await axios.get(api.reservation.reservations)

        setData(response.data)
    }

    return (
        <Container style={styles.statusBarPadding}>
            <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.green })} />
                <Text category='h3' style={{ fontWeight: 'bold', paddingHorizontal: 16, paddingBottom: 16, backgroundColor: colors.white }}>My Bookings</Text>
            </View>
            {data && <ScrollView>
                {data.reservations.map(reservation => (
                    <View style={{ marginBottom: 24 }}>
                        <ImageBackground
                            style={styles.modalHeaderImage}
                            source={{ uri: reservation.restaurantImage }}
                            imageStyle={{ borderRadius: 16 }}>
                        </ImageBackground>
                        <View style={{ flexDirection: 'row', paddingVertical: 16 }}>
                            <Text style={styles.subheader}>Order #{reservation.reservationId}</Text>
                            <Text style={styles.subheader}> | {moment(reservation.dateAndTime).format('DD MMM YYYY [at] HH:mm')}</Text>
                        </View>
                        <View>
                            {reservation.menuItems.map(p => (
                                <View style={{ flexDirection: 'row' }}>
                                    <Text style={styles.menuItemQuantity}>{p.quantity}</Text>
                                    <View>
                                        <Text style={{ ...material.button }}>{p.name}</Text>
                                        <Text style={material.caption}>{p.description}</Text>
                                    </View>
                                    <PriceTag price={p.price} count={p.quantity} />
                                </View>
                            ))}
                        </View>
                        <Divider style={{ marginVertical: 24 }} />
                        <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
                            <Text category='p1' style={{ fontWeight: 'bold' }}>Total</Text>
                            <PriceTag price={reservation.price} />
                        </View>
                        {/* <იეწ></იეწ> */}
                        <View style={{ flexDirection: 'row', justifyContent: 'space-between', marginTop: 16 }}>
                            <Button appearance='ghost' textStyle={material.buttonWhite} style={{ backgroundColor: colors.green, width: '48%' }}>Reorder</Button>
                            <Button appearance='ghost' textStyle={material.button} style={{ backgroundColor: colors.lightGrey, width: '48%' }}>Cancel</Button>
                        </View>
                    </View>
                ))}
            </ScrollView>}
        </Container>
    )
}

const { Navigator, Screen } = createStackNavigator()

export default () => (
    <Navigator screenOptions={{ headerShown: false }}>
        <Screen name='AccountMenu' component={Account} />
        <Screen name='AccountBookings' component={AccountBookings} />
    </Navigator>
)
