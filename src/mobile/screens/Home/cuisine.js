import React, { useState } from 'react'
import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions, StatusBar, Image } from 'react-native'
import { ScrollView } from 'react-native-gesture-handler'
import CategoryList from '../../components/Category/CategoryList'
import CuisineList from '../../components/Cuisine/CuisineList'
import CuisineListVertical from '../../components/Cuisine/CuisineListVertical'
import { colors } from '../../variables/colors'
import { Back } from '../../components/Icons'
import Filter from '../../components/Filter'
import PageHeader from '../../components/PageHeader'

const Cuisine = () => {

    return (
        <>
            <Layout>
                <PageHeader />
                <Filter />
                <CuisineListVertical style={{ margin: 15 }} />
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
        backgroundColor: colors.green
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