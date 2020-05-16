import React, { useState } from 'react'

import { products } from '../../mock-data/products'

import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions } from 'react-native'

const AvailableIcon = (style) => (
    <Icon {...style} name='bookmark-outline' />
);

const NotAvailableIcon = (style) => (
    <Icon {...style} name='bookmark' />
);

const StarIcon = (style) => (
    <Icon {...style} name='star' fill='#FFB700' />
);

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

        <Text category='s1' style={{ fontWeight: 'bold' }}>{info.item.title}</Text>
        <Text appearance='hint' category='c2'>
            {info.item.cuisine}
        </Text>
        <View style={styles.rating}>
            <StarIcon width={16} height={16} />
            <Text category='s2' style={{ fontWeight: 'bold', alignSelf: 'flex-start' }}>{info.item.rating}</Text>
            <Text appearance='hint' category='c2' style={{ alignSelf: 'flex-end' }}>({info.item.reviewsCount} reviews)</Text>
        </View>
    </View>
);

const CategoryList = (props) => (
    <List
        contentContainerStyle={styles.productList}
        data={products}
        // data={props.restaurants}
        horizontal
        renderItem={renderProductItem}
    />
)

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
        marginRight: 8,
        marginTop: 8,
        marginBottom: 8,
        maxWidth: Dimensions.get('window').width / 2 - 24,
        backgroundColor: 'background-basic-color-1',
    },
    itemHeader: {
        height: 100,
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
    }
});

export default CategoryList