import React, { useState } from 'react'

import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions } from 'react-native'
import { colors } from '../../variables/colors';
import { SafeAreaView } from 'react-native-safe-area-context';

const renderItemHeader = (info) => (
    <ImageBackground
        style={styles.itemHeader}
        source={{ uri: info.item.image }}
        imageStyle={{
            borderTopLeftRadius: 9,
            borderTopRightRadius: 9,
        }}
        resizeMode='contain'
    />
);

const renderCuisineItem = (info) => (
    <View
        style={styles.cuisineItem}
        onPress={() => onItemPress(info.index)}>
        {renderItemHeader(info)}

        <Text category='s1' style={{ fontWeight: 'bold', textAlign: 'center' }}>{info.item.title}</Text>
        <Text category='c2' appearance='hint' style={{ textAlign: 'center' }}>{info.item.restaurantQuantity} Restaurants</Text>

        <Text category='c2' />
    </View>
);

const CuisineListVertical = (props) => (
    <List
        numColumns={2}
        contentContainerStyle={styles.cuisineList}
        data={props.cuisines}
        renderItem={renderCuisineItem}
    />
)

const styles = StyleService.create({
    cuisineList: {
        paddingVertical: 16,
        marginBottom: 40,
        borderRadius: 9,
        backgroundColor: colors.white
    },
    cuisineItem: {
        flex: 1,
        marginRight: 8,
        marginTop: 8,
        marginBottom: 8,
        // paddingBottom: 16,
        width: Dimensions.get('window').width / 2 - 48,
        borderRadius: 9,
        backgroundColor: colors.creamy
    },
    itemHeader: {
        height: 100,
        justifyContent: 'flex-end',
        flexDirection: 'column',
        justifyContent: 'space-between',
        borderRadius: 9,
        margin: 5,
        marginLeft: 10,
        marginRight: 10,
    }
});

export default CuisineListVertical