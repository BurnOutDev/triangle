import React, { useState } from 'react'
import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions, StatusBar, Image, ScrollView, Linking, TouchableOpacity, Alert } from 'react-native'
import CategoryList from '../../components/Category/CategoryList'
import CuisineList from '../../components/Cuisine/CuisineList'
import Filter from '../../components/Filter'
import Category from '../../components/Category/Category'
import ReferalPromo from '../../components/ReferalPromo'
import Promo from '../../components/Promo'
import { colors } from '../../variables/colors'
import Cuisine from '../../components/Cuisine/Cuisine'
import Address from '../../components/Address'
import { createStackNavigator } from '@react-navigation/stack'
import Container from '../../components/Container'
import MostPopular from './MostPopular'
import PageHeader from '../../components/PageHeader'
import axios from '../../axios'
import InAppBrowser from 'react-native-inappbrowser-reborn'

const Explore = (props) => {

    const payment = () => {
        debugger
        const items = [
            { product_id: "123456789", quantity: 1, amount: 1.00, description: "product description text 1" },
        ];

        const ip = require('../../config.json').ip

        axios.post(`http://${ip}:3000/pay`, items).then(res => {
            openLink(res.data.links[1].href)
            axios.post(`http://${ip}:3000/view-log`, res.data)
        }).catch(err => {
            debugger
            Alert.alert('Error')
        })
    }

    const openLink = async (url) => {
        try {
            if (await InAppBrowser.isAvailable()) {
                debugger
                const result = await InAppBrowser.openAuth(url, 'com.reserveapp:/paymentredirect', {
                    // iOS Properties
                    dismissButtonStyle: 'cancel',
                    preferredBarTintColor: '#453AA4',
                    preferredControlTintColor: 'white',
                    readerMode: false,
                    animated: true,
                    modalPresentationStyle: 'fullScreen',
                    modalTransitionStyle: 'partialCurl',
                    modalEnabled: true,
                    enableBarCollapsing: false,
                    // Android Properties
                    showTitle: true,
                    toolbarColor: '#6200EE',
                    secondaryToolbarColor: 'black',
                    enableUrlBarHiding: true,
                    enableDefaultShare: true,
                    // Specify full animation resource identifier(package:anim/name)
                    // or only resource name(in case of animation bundled with app).
                    animations: {
                        startEnter: 'slide_in_right',
                        startExit: 'slide_out_left',
                        endEnter: 'slide_in_left',
                        endExit: 'slide_out_right'
                    }
                })
            }
            else Linking.openURL(url)
        } catch (error) {
            Alert.alert(error.message)
        }
    }

    return (
        <Container>
            <PageHeader statusBarPadding showFilter />
            <ScrollView>
                <TouchableOpacity onPress={payment}>
                    <Address />
                    <Promo />
                </TouchableOpacity>
                <Category title='Nearby' />
                <Category title='Best offers' horizontal />
                <Category title='Best rated' />
                <Category title='Featured' />
                <Cuisine />
                <ReferalPromo />
            </ScrollView>
        </Container>
    )
}

export default Explore