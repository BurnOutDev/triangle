import React, { useState, Component } from 'react'
import { View, StatusBar, StyleSheet, ImageBackground, Image, SafeAreaView } from 'react-native'
import { Text, Layout, Input, Button, Icon } from '@ui-kitten/components'
import { colors } from '../../variables/colors'
import PageHeader from '../../components/PageHeader'
import CuisineListVertical from '../../components/Cuisine/CuisineListVertical'
import { Search, Star, Location } from '../../components/Icons'
import Filter from '../../components/Filter'
import RestaurantList from '../../components/RestaurantList/RestaurantList'
import Container from '../../components/Container'
import axios from '../../axios'
import { Splash } from '../Screens'
import api from '../../variables/api'

const CategoryAll = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.get(api.restaurant.restaurants)

        setData(response.data)
    }

    return (
        <Container>
            <PageHeader title='Coffee shop' />
            <Filter />
            <Header />
            {data ? <RestaurantList title='Most popular' restaurants={data.restaurants} /> : <Splash />}
        </Container>
    )
}

const Header = () => 
<ImageBackground style={{ height: 150, width: 'auto', flexDirection: 'column-reverse' }} source={require('../../assets/girl.jpg')} resizeMode='cover'>
    <Text category='h1' style={{ color: 'white', padding: 15, paddingRight: 100 }}>Top rated coffee shop</Text>
</ImageBackground>

export default CategoryAll