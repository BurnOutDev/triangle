import React, { useState } from 'react'
import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions, StatusBar, Image } from 'react-native'
import RestaurantsList from './RestaurantList'
import { ScrollView } from 'react-native-gesture-handler'
import CategoryList from './CategoryList'
import CategoryXLList from './CategoryXLList'
import CuisineList from './CuisineList'
import CuisineListVertical from './CuisineListVertical'
import { colors } from '../../variables/colors'

const green = '#277e6d'

const ArrowIcon = (props) => (
    <Icon {...props} name='arrow-back' />
);

const Search = (style) => (
    <Icon {...style} width='16' height='16' fill='green' name='search' />
)

const Filter = () => {
    const [value, setValue] = React.useState('');

    return (
        <View style={styles.filterContainer}>
            <Input
                size='small'
                placeholder='Cuisine, restaurant name...'
                value={value}
                onChangeText={nextValue => setValue(nextValue)}
                icon={Search}
            />
        </View>
    )
}

const Cuisines = (props) => (
    <View style={{ margin: 15 }}>
        <CuisineListVertical />
    </View>
)

const Header = (props) => (
    <View style={{ backgroundColor: colors.green }}>
        <Button style={{ position: 'absolute', zIndex: 2 }}  appearance='ghost' status='basic' icon={ArrowIcon} />
        <Text style={{ textAlign: 'center', color: colors.white }} category='h5'>Cuisine</Text>
    </View>
)

const Cuisine = () => {

    return (
        <>
            <StatusBar backgroundColor={green} />
            <Layout>
                <Header />
                <Filter />
                <ScrollView>
                    <Cuisines />
                </ScrollView>
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

export default Cuisine