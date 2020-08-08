import React, { useState, Component } from 'react'
import { View, StatusBar, StyleSheet, ImageBackground, Image, SafeAreaView, Dimensions } from 'react-native'
import { Text, Layout, Input, Button, Icon, StyleService, Divider } from '@ui-kitten/components'
import CategoryXLList from '../../components/CategoryXL/CategoryXLList'
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

const StarIcon = (style) => (
    <Icon {...style} name='star' fill='#FFB700' />
);

const MostPopular = (props) => {
    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.get(api.restaurant.restaurants)

        setData(response.data)
    }

    return (
        <Container>
            <PageHeader title='Most popular' />
            <Filter />
            {data ? <RestaurantList title='Most popular' restaurants={data.restaurants} header={<Header {...data.restaurants[0]} />} /> : <Splash />}
        </Container>
    )
}

const Header = (info) =>
    <View
        style={styles.productItem}
    >
        <Text category='h2' style={{ fontWeight: 'bold', marginBottom: 8 }}>Featured this week</Text>

        <ImageBackground
            style={styles.itemHeader}
            source={{ uri: info.image }}
            imageStyle={{ borderRadius: 9 }}
        />

        <Text category='h5' style={{ fontWeight: 'bold' }}>{info.title}</Text>
        <Text appearance='hint' category='p1'>
            {info.cuisine}
        </Text>
        <View style={styles.rating}>
            <StarIcon width={16} height={16} fill={'black'} />
            <Text category='h6' style={{ fontWeight: 'bold', marginLeft: 1 }}>{info.rating}</Text>
            <Text appearance='hint' category='c2' style={{ marginLeft: 3 }}>{info.reviewsCount} reviews</Text>
        </View>
    </View>

const styles = StyleService.create({
    container: {
        flex: 1,
        backgroundColor: 'background-basic-color-2',
    },
    productList: {
        paddingVertical: 16,
    },
    productItem: {
        flex: 1,
        margin: 8,
        backgroundColor: 'background-basic-color-1',
    },
    itemHeader: {
        height: 150,
        justifyContent: 'flex-end',
        flexDirection: 'column',
        justifyContent: 'space-between'
    },
    rating: {
        flexDirection: 'row',
        // alignSelf: 'flex-start',
        alignItems: 'center',
        marginRight: 10,
    }
});

export default MostPopular