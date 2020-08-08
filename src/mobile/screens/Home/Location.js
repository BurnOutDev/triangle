import React, { useState } from 'react'
import { View, StatusBar, StyleSheet, ImageBackground } from 'react-native'
import { Text, Layout, Input, Button, Icon } from '@ui-kitten/components'
import CategoryXLList from '../../components/CategoryXL/CategoryXLList'
import { colors } from '../../variables/colors'
import PageHeader from '../../components/PageHeader'
import CuisineListVertical from '../../components/Cuisine/CuisineListVertical'
import { Search, Star } from '../../components/Icons'

export const Location = (style) => (
    <Icon {...style} fill={colors.green} name='pin-outline' />
)

const Header = () => {
    const [value, setValue] = React.useState('');

    return (
        <ImageBackground source={require('../../assets/girl.jpg')} resizeMode='cover' style={{}}>
            <View style={styles.filterContainer}>
                <Input
                    size='small'
                    placeholder='Cuisine, restaurant name...'
                    value={value}
                    onChangeText={nextValue => setValue(nextValue)}
                    icon={Search}
                    style={{ flex: 3 }}
                />
                <Button appearance='ghost' size='small' icon={Location} />
            </View>
            <View style={{ margin: 15, marginTop: 90 }}>
                <Text style={{ fontWeight: 'bold', color: 'white' }}>Featured</Text>

                <Text category='h1' style={{ color: 'white', fontWeight: 'bold' }}>Blackstarz Coffee</Text>
                <View style={styles.rating}>
                    <Star height={16} />
                    <Text category='s2' style={{ color: 'white', fontWeight: 'bold', alignSelf: 'flex-start', paddingRight: 5, marginBottom:-4 }}>4.9</Text>
                    <Text appearance='hint' category='c2' style={{ color: 'white', alignSelf: 'flex-end', paddingRight: 5 }}>(210 reviews)</Text>
                    <Text appearance='hint' category='c2' style={{ color: 'white', alignSelf: 'flex-end', paddingRight: 5 }}>Cafe • $$</Text>
                </View>
            </View>
        </ImageBackground>
    )
}

const Category = (props) => (
    <>
        <Layout>
            <Header />
            <Category title='Most popular' horizontal />
        </Layout>
    </>
)

const styles = StyleSheet.create({
    filterContainer: {
        padding: 15,
        marginTop: StatusBar.currentHeight,
        backgroundColor: 'transparent',
        flexDirection: 'row',
        justifyContent: 'space-between'
    },
    rating: {
        flexDirection: 'row',
        alignSelf: 'flex-start',
        marginRight: 10,
        marginBottom: 15
    }
})

export default Category