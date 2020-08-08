import React from 'react'
import { useNavigation } from '@react-navigation/native'
import axios from '../../axios'
import api from '../../variables/api'
import { StyleService, Button, Text, Divider } from '@ui-kitten/components'
import { StatusBar, View, ScrollView, ImageBackground } from 'react-native'
import Container from '../../components/Container'
import { material } from 'react-native-typography'
import { colors } from '../../variables/colors'
import { Back } from '../../components/Icons'; import moment from 'moment'
import PriceTag from '../../components/PriceTag'

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

export default AccountBookings