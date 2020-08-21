import React, { useState } from 'react'
import { Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService, Layout } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions, StatusBar, Image } from 'react-native'
import { ScrollView } from 'react-native-gesture-handler'
import CategoryList from '../../components/Category/CategoryList'
import CuisineList from '../../components/Cuisine/CuisineList'
import CuisineListVertical from '../../components/Cuisine/CuisineListVertical'
import { colors } from '../../variables/colors'
import { Back } from '../../components/Icons'
import Filter from '../../components/Filter'
import PageHeader from '../../components/PageHeader'
import Container from '../../components/Container'
import axios from '../../axios'
import { SafeAreaView } from 'react-native-safe-area-context'
import { SafeAreaLayoutComponent } from '../../components/SafeAreaLayout'
import { Splash } from '../Screens'
import api from '../../variables/api'

const Cuisine = () => {

    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.get(api.restaurant.cuisines)

        setData(response.data)
    }

    return (
        <Container>
            <PageHeader title='Cuisine' showFilter />
            {data ? <CuisineListVertical cuisines={data.cuisines} /> : <Splash />}
        </Container>
    )
}

export default Cuisine