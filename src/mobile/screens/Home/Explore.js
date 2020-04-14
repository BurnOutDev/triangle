import React, { useState } from 'react'
import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions, StatusBar } from 'react-native'
import RestaurantsList from './RestaurantList'

const green = '#277e6d'

const LocationIcon = (style) => (
    <Icon {...style} width='16' height='16' fill='green' name='pin-outline' />
);

const ArrowRightIcon = (style) => (
    <Icon {...style} width='16' height='16' fill='green' name='chevron-right' />
);

const Filter = () => {
    const [value, setValue] = React.useState('');

    return (
        <View style={styles.filterContainer}>
            <Input
                size='small'
                placeholder='Cuisine, restaurant name...'
                value={value}
                onChangeText={nextValue => setValue(nextValue)}
            />
        </View>
    )
}

const Address = () => (
    <View style={{padding: 15}}>
        <Text category='h1'>Current</Text>
        <View style={{flexDirection: 'row'}}>
            <LocationIcon />
            <Text style={{color: green, lineHeight: 18, paddingLeft: 4}}>Unit 10, 2F, 123 York Street</Text>
            <ArrowRightIcon />
        </View>
    </View>
)

const Promo = () => (
    <View style={{marginLeft: 15, marginRight: 15, backgroundColor: green, borderRadius: 10 }}>
        <Text category='h4' style={{color: 'white', padding: 30, textAlign: 'center' }}>Get 50% Off Food Discount</Text>
    </View>
)

const Explore = () => {

    return (
        <>
            <StatusBar backgroundColor={green} />
            <Layout>
                <Filter />
                <Address />
                <Promo />
                {/* <RestaurantsList /> */}
            </Layout>
        </>
    )
}

const styles = StyleSheet.create({
    layout: {

    },
    imageBg: {
        resizeMode: 'cover',
        paddingLeft: 15,
        paddingRight: 15,
        paddingTop: 75,
        paddingBottom: 50,
        borderRadius: 20,
    },
    headerText: {
        color: 'white',
        fontWeight: 'bold'
    },
    headerContainer: {
        borderRadius: 20
    },
    filterContainer: {
        padding: 15,
        backgroundColor: green
    },
    filterButtonsContainer: {
        flexDirection: 'row',
        justifyContent: 'space-evenly',
        marginTop: 15
    },
    filterButton: {
    }
})

export default Explore