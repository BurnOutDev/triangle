import React, { useState } from 'react'

import { products } from '../../mock-data/products'

import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions } from 'react-native'
import { Star } from '../Icons'

const displayProducts = products

const renderItemHeader = (info) => (
    <>
        <ImageBackground
            style={styles.itemHeader}
            source={info.item.image}
            imageStyle={{ borderRadius: 9 }}
        />
    </>
);

const renderProductItem = (info) => (
    <View
        style={styles.productItem}
        onPress={() => onItemPress(info.index)}>
        {renderItemHeader(info)}

        <View style={styles.content}>
            <Text category='h6' style={{ fontWeight: 'bold' }}>{info.item.title}</Text>
            <Text appearance='hint' category='s1'>
                {info.item.category} • $
            </Text>
            <View style={styles.rating}>
                <Star />
                <Text category='s1' style={{ fontWeight: 'bold' }}>{info.item.rating}</Text>
                <Text appearance='hint' category='s1' style={{ paddingLeft: 5 }}>({info.item.reviewsCount} reviews)</Text>
            </View>
        </View>
    </View>
);

const RestaurantList = () => (
    <List
        contentContainerStyle={styles.productList}
        data={displayProducts.length && displayProducts || products}
        renderItem={renderProductItem}
        style={{height: 'auto'}}
    />
)

const styles = StyleService.create({
    container: {
        flex: 1,
        backgroundColor: 'background-basic-color-2',
    },
    productList: {
        padding: 16,
    },
    productItem: {
        flex: 1,
        marginRight: 8,
        marginTop: 8,
        marginBottom: 8,
        maxWidth: Dimensions.get('window').width - 24,
        backgroundColor: 'background-basic-color-1',
        flexDirection: 'row'
    },
    itemHeader: {
        height: 80,
        width: 80,
        justifyContent: 'flex-end',
        flexDirection: 'column',
        justifyContent: 'space-between'
    },
    itemFooter: {
        flexDirection: 'row',
        justifyContent: 'flex-start',
    },
    iconButton: {
        flexDirection: 'row',
        paddingHorizontal: 0,
        alignSelf: 'flex-end'
    },
    rating: {
        flexDirection: 'row',
        alignSelf: 'flex-start',
        marginRight: 10,
        alignItems: 'center',
    },
    content: {
        paddingLeft: 10
    }
});

export default RestaurantList