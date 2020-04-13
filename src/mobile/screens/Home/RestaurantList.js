import React, { useState } from 'react'

import { products } from './products'

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

const displayProducts = products

const renderItemHeader = (info) => (
    <>
        <ImageBackground
            style={styles.itemHeader}
            source={info.item.image}
            imageStyle={{ borderRadius: 9 }}
        >
              <Button
                style={styles.iconButton}
                appearance='ghost'
                size='small'
                status={info.item.reservationAvailable ? 'success' : 'danger'}
                icon={NotAvailableIcon}
                // icon={info.item.reservationAvailable ? AvailableIcon : NotAvailableIcon}
            />
            <View style={styles.rating}>
                <StarIcon width={16} height={16} />
                <Text category='s2'>{info.item.rating}</Text>
            </View>
        </ImageBackground>
    </>
);

const renderProductItem = (info) => (
    <View
        style={styles.productItem}
        onPress={() => onItemPress(info.index)}>
        {renderItemHeader(info)}

        <View>
            <View>
                <Text category='s1'>{info.item.title}</Text>
                <Text appearance='hint' category='c2'>
                    {info.item.address}
                </Text>
                <Text appearance='hint' category='c2'>
                    {info.item.category}
                </Text>
            </View>
            <View>

            </View>
        </View>
    </View>
);

const RestaurantsList = () => (
    <List
        contentContainerStyle={styles.productList}
        data={displayProducts.length && displayProducts || products}
        numColumns={2}
        renderItem={renderProductItem}
    />
)

const styles = StyleService.create({
    container: {
        flex: 1,
        backgroundColor: 'background-basic-color-2',
    },
    productList: {
        paddingHorizontal: 8,
        paddingVertical: 16,
    },
    productItem: {
        flex: 1,
        margin: 8,
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
        marginRight: 10
    }
});

export default RestaurantsList