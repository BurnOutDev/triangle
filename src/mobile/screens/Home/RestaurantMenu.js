import React from 'react';
import Container from '../../components/Container';
import PageHeader from '../../components/PageHeader';
import { Filter, Back } from '../../components/Icons';
import RestaurantList from '../../components/RestaurantList/RestaurantList';
import { View } from 'react-native';
import { Icon, TopNavigationAction, Button, Text, Divider, StyleService } from '@ui-kitten/components';
import PageHeaderContainer from '../../components/PageHeaderContainer';
import { colors } from '../../variables/colors';
import { Svg, Line } from 'react-native-svg';
import Category from '../../components/Category/Category';
import CategoryList from '../../components/Category/CategoryList';
import axios from '../../axios';
import { Splash } from '../Screens';
import MenuHorizontalList from '../../components/Menu/MenuHorizontalList';
import MenuVerticalList, { Addon } from '../../components/Menu/MenuVerticalList';
import { TouchableOpacity } from 'react-native-gesture-handler';
import SingleButton from '../../components/SingleButton';
import { material } from 'react-native-typography';
import api from '../../variables/api';
import AsyncStorage from '@react-native-community/async-storage';

const RestaurantMenu = (props) => {
    const [data, setData] = React.useState(null)
    const [checkoutSum, setCheckoutSum] = React.useState(0)

    React.useEffect(() => { if (data == null) getData() }, []);
    const [showSelected, setShowSelected] = React.useState(false)
    const getData = async () => {

        debugger
        const response = await axios.get(`Menu/GetMenuItems/${props.route.params.restaurantId}`)

        setData({
            ...response.data,
            menuItems: response.data.menuItems.map(_ => ({
                ..._,
                visible: true
            }))
        })
    }

    const updateCheckoutSum = () => {
        let sum = data.menuItems.map(item => item.count > 0 ? item.count * item.price : 0).reduce((a, b) => a + b, 0)

        if (sum === 0 && showSelected) {
            ShowSelected()
        }

        setCheckoutSum(sum)
    }

    const ShowSelected = () => {
        setShowSelected(!showSelected)

        setData({
            ...data,
            menuItems: data.menuItems.map(_ => ({
                ..._,
                visible: showSelected || _.count > 0
            }))
        })
    }

    const Checkout = () => {
        props.navigation.navigate('BookATable', {
            restaurant: props.route.params.restaurant,
            menuItems: data.menuItems
        })

        AsyncStorage.setItem()
    }

    return (
        <Container style={{ backgroundColor: colors.white }}>
            <Header />
            <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
                <Text category='h3' style={{ fontWeight: 'bold', paddingHorizontal: 16, paddingBottom: 16, backgroundColor: colors.white }}>Menu</Text>
                {checkoutSum > 0 && <TouchableOpacity
                    style={[styles.addonButton, showSelected && { backgroundColor: colors.active }]}
                    onPress={ShowSelected}>
                    <Text style={showSelected ? styles.addonTextActive : styles.addonText}>{showSelected ? 'Show All' : 'Show Selected Only'}</Text>
                </TouchableOpacity>}
                {checkoutSum > 0 && <Text style={{ ...material.headline, color: colors.green, paddingHorizontal: 8 }}>{`$${checkoutSum}`}</Text>}
            </View>
            {data ? <MenuVerticalList title='Most popular' menuItems={data.menuItems} onChange={updateCheckoutSum} style={{}} /> : <Splash />}
            {checkoutSum > 0 &&
                <SingleButton text={`Go to checkout`} onPress={Checkout}
                    style={{ marginVertical: 24 }} />}
        </Container>
    )
}

const Header = (props) =>
    <PageHeaderContainer style={{ backgroundColor: colors.white }}>
        <Button appearance='ghost' status='basic' icon={() => Back({ fill: colors.green })} />
    </PageHeaderContainer>

const MenuSpecial = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.get(api.menu.menuItems)

        setData(response.data)
    }

    return (
        <View style={{ paddingVertical: 8, paddingHorizontal: 16, backgroundColor: colors.creamy }}>
            <View style={{ flexDirection: 'row' }}>
                <StarIcon width={16} height={16} />
                <Divider style={{ marginHorizontal: 4 }} />
                <Text>{props.title}</Text>
                <Divider style={{ marginHorizontal: 4 }} />
                <Svg height="2" width="200" style={{ flexDirection: 'column', flex: 1, alignItems: 'center', alignSelf: 'center' }}>
                    <Line x1="0" y1="0" x2="200" y2="0" stroke="#FFB700" strokeWidth="3" />
                </Svg>
            </View>
            {data ? <MenuHorizontalList menuItems={data.menuItems} /> : <Splash />}
        </View>
    )
}

const BackIcon = (props) => (
    <Icon {...props} name='arrow-back' />
);


const StarIcon = (style) => (
    <Icon {...style} name='star' fill='#FFB700' />
);

const styles = StyleService.create({
    checkoutContainer: {
        flexDirection: 'row',
        backgroundColor: colors.green,
        height: 40,
        alignItems: 'center',
        justifyContent: 'space-between',
        paddingHorizontal: 16
    },
    addonButton: {
        backgroundColor: colors.lightGrey,
        borderRadius: 32,
        height: 40,
        width: 150,
        paddingHorizontal: 16,
        flexDirection: 'column',
        justifyContent: 'center',
        marginBottom: 16,
        marginRight: 4
    },
    addonText: {
        ...material.caption,
        fontWeight: 'bold',
        textAlign: 'center'
    },
    addonTextActive: {
        ...material.captionWhite,
        fontWeight: 'bold',
        textAlign: 'center'
    },
})

export default RestaurantMenu