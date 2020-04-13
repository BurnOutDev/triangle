import React, { useState } from 'react'
import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions } from 'react-native'

const styles2 = StyleService.create({
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
      height: 140,
    },
    itemFooter: {
      flexDirection: 'row',
      justifyContent: 'space-between',
      alignItems: 'center',
    },
    iconButton: {
      paddingHorizontal: 0,
    },
  });

const Header = () => (
    <ImageBackground style={styles.headerContainer} resizeMode='cover' source={require('../../assets/HomeHeaderBg.png')} style={styles.imageBg}>
        <Text style={styles.headerText} category='h1'>Home</Text>
        <Text style={styles.headerText} category='h5'>Where would you like to reserve your table ?</Text>
    </ImageBackground>
)

const CartIcon = (style) => (
    <Icon {...style} name='shopping-cart'/>
  );

const Filter = () => {
    const [value, setValue] = React.useState('');

    return (
        <View style={styles.filterContainer}>
            <Input
                size='small'
                placeholder='Search Restaurant'
                value={value}
                onChangeText={nextValue => setValue(nextValue)}
            />
            <View style={styles.filterButtonsContainer}>
                <Button style={styles.filterButton} size='small' appearance='filled'>All</Button>
                <Button style={styles.filterButton} size='small' appearance='ghost'>Polular</Button>
                <Button style={styles.filterButton} size='small' appearance='ghost'>Near by</Button>
                <Button style={styles.filterButton} size='small' appearance='ghost'>Recent</Button>
            </View>
        </View>
    )
}

const data = new Array(8).fill({
    title: 'Item',
});

const renderItem = ({ item, index }) => (
    <ListItem title={`${item.title} ${index + 1}`} />
);

/////////////////////////

const renderItemFooter = (info) => (
    <View style={styles2.itemFooter}>
        <Text category='s1'>
            {info.item.formattedPrice}
        </Text>
        <Button
            style={styles2.iconButton}
            size='small'
            icon={CartIcon}
        />
    </View>
);

const renderItemHeader = (info) => (
    <ImageBackground
        style={styles2.itemHeader}
        source={info.item.image}
    />
);

const renderProductItem = (info) => (
    <Card
        style={styles2.productItem}
        header={() => renderItemHeader(info)}
        footer={() => renderItemFooter(info)}
        onPress={() => onItemPress(info.index)}>
        <Text category='s1'>
            {info.item.title}
        </Text>
        <Text
            appearance='hint'
            category='c1'>
            {info.item.category}
        </Text>
    </Card>
);

const products = [
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    },
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    },
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    },
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    },
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    },
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    },
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    },
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    },
    {
        title: 'Pink Chair',
        category: 'Furniture',
        image: require('../../assets/image-product-1.png'),
        price: 130,
        amount: 1
    }
];

const displayProducts = products

/////////////////////////

const RestaurantsList = () => (
    <List
        contentContainerStyle={styles.productList}
        data={displayProducts.length && displayProducts || products}
        numColumns={2}
        renderItem={renderProductItem}
    />
)

const Explore = () => {

    return (
        <Layout>
            <Header />
            <Filter />
            <RestaurantsList />
        </Layout>
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
        marginTop: -30
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