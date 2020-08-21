import React, { useState } from 'react'

import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions } from 'react-native'
import { TouchableOpacity } from 'react-native-gesture-handler';
import PriceTag from '../PriceTag';

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
            source={{uri: info.item.imageUrl}}
            imageStyle={{ borderRadius: 9 }}
        />
    </>
);

const renderProductItem = (info) => (
    <TouchableOpacity
        style={styles.productItem}>
        {renderItemHeader(info)}

        <Text category='s1'>{info.item.name}</Text>
        <PriceTag price={info.item.price} />
    </TouchableOpacity>
);

const MenuHorizontalList = (props) => (
    <List
        contentContainerStyle={styles.productList}
        data={props.menuItems}
        horizontal
        renderItem={renderProductItem}
        style={{backgroundColor: 'transparent', marginRight: -16, marginLeft: -16, paddingLeft: 16 }}
        ListHeaderComponent={props.header}
    />
)

const styles = StyleService.create({
    container: {
        flex: 1,
        backgroundColor: 'background-basic-color-2',
    },
    productList: {
        paddingTop: 16,
    },
    productItem: {
        flex: 1,
        marginRight: 8,
        marginTop: 8,
        marginBottom: 8,
        width: 100,
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
        // alignSelf: 'flex-start',
        alignItems: 'center',
        marginRight: 10,
    }
});

export default MenuHorizontalList