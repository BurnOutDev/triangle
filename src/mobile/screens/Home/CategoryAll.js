import React, { useState } from 'react'
import { View, StatusBar, StyleSheet, ImageBackground, Image, SafeAreaView } from 'react-native'
import { Text, Layout, Input, Button, Icon } from '@ui-kitten/components'
import CategoryXLList from '../../components/CategoryXL/CategoryXLList'
import { colors } from '../../variables/colors'
import PageHeader from '../../components/PageHeader'
import CuisineListVertical from '../../components/Cuisine/CuisineListVertical'
import { Search, Star, Location } from '../../components/Icons'
import CategoryXL from '../../components/CategoryXL/CategoryXL'
import Filter from '../../components/Filter'
import RestaurantList from '../../components/RestaurantList/RestaurantList'

const CategoryAll = (props) => (
    <>
        <Layout>
            <PageHeader title='Coffee shop' />
            <Filter />
            <ImageBackground style={{ height: 150, width: 'auto', flexDirection: 'column-reverse' }} source={require('../../assets/girl.jpg')} resizeMode='cover'>
                <Text category='h1' style={{ color: 'white', fontWeight: 'bold', padding: 15, paddingRight: 100 }}>Top rated coffee shop</Text>
            </ImageBackground>
            <RestaurantList title='Most popular' />
        </Layout>
    </>
)

const styles = StyleSheet.create({
    filterContainer: {
        padding: 15,
        marginTop: StatusBar.currentHeight,
        backgroundColor: 'transparent',
        flexDirection: 'row',
        justifyContent: 'space-between'
    },
    rating: {
        flexDirection: 'row',
        alignSelf: 'flex-start',
        marginRight: 10,
        marginBottom: 15
    }
})

export default CategoryAll