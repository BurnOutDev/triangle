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
import axios from '../../axios'
import { Splash } from '../Screens'

const CategoryAll = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.get('Restaurant/Restaurants')

        setData(response.data)
    }

    return (
        <Container>
            <PageHeader title='Coffee shop' />
            <Filter />
            {data ? <RestaurantList title='Most popular' restaurants={data.restaurants} /> : <Splash />}
        </Container>
    )
}

export default CategoryAll