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

const Explore = () => (
    <>
        <Layout>
            <Filter statusBarPadding bottomPadding />
            <ScrollView>
                <Address />
                <Promo />
                <Category title='Nearby' />
                <CategoryXL title='Best offers' />
                <Category title='Best rated' />
                <Category title='Nearby' />
                <Cuisine />
                <ReferalPromo />
            </ScrollView>
        </Layout>
    </>
)

export default Explore