import React, { useState, Component } from 'react'
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
import Container from '../../components/Container'

const CategoryAll = (props) => (
    <>
        <Container>
            <PageHeader title='Coffee shop' />
            <Filter />
            <RestaurantList title='Most popular' />
        </Container>
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