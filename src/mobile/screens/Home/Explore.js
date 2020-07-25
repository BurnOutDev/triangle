import React, { useState } from 'react'
import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions, StatusBar, Image } from 'react-native'
import { ScrollView } from 'react-native-gesture-handler'
import CategoryList from '../../components/Category/CategoryList'
import CuisineList from '../../components/Cuisine/CuisineList'
import Filter from '../../components/Filter'
import Category from '../../components/Category/Category'
import ReferalPromo from '../../components/ReferalPromo'
import Promo from '../../components/Promo'
import { colors } from '../../variables/colors'
import CategoryXL from '../../components/CategoryXL/CategoryXL'
import Cuisine from '../../components/Cuisine/Cuisine'
import Address from '../../components/Address'
import { createStackNavigator } from '@react-navigation/stack'
import { AuthContext } from '../context'
import Container from '../../components/Container'

const { Navigator, Screen } = createStackNavigator();

const header = () => (
    <Filter statusBarPadding />
)

const Explore = () => {    
    return (
        <Container>
            <ScrollView>
                <Address />
                <Promo />
                <Category title='Nearby' />
                <CategoryXL title='Best offers' />
                <Category title='Best rated' />
                <Category title='Featured' />
                <Cuisine />
                <ReferalPromo />
            </ScrollView>
        </Container>
    )
}

export default () => (
    <Navigator>
        <Screen name="Home" component={Explore} options={{ header }} />
    </Navigator>
)