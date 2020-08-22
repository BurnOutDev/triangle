import React, { useState, Fragment } from 'react'

import { Layout, Text, Input, Button, List, ListItem, Card, Icon, useStyleSheet, StyleService, Divider, Modal } from '@ui-kitten/components'
import { ImageBackground, StyleSheet, View, Dimensions, TouchableOpacity } from 'react-native'
import { Star, MinusIcon, PlusIcon, CheckIcon } from '../Icons'
import PriceTag from '../PriceTag'
import { colors } from '../../variables/colors'
import { material, systemWeights } from 'react-native-typography'
import SingleButton from '../SingleButton'
import log from '../../log'

const RenderProductItem = ({ item, onUpdate }) => {
    const [clicked, setClicked] = React.useState(false)
    const [addons, setAddons] = React.useState([
        { text: 'Add Buffalo' },
        { text: 'Add Chilli' },
        { text: 'Dairy Free' },
        { text: 'Add Chicken' },
        { text: 'Add Chorizo' },
    ])

    const [count, setCount] = React.useState(1)

    const [isUpdate, setIsUpdate] = React.useState(false)

    const click = () => {
        setClicked(!clicked)
    }

    const onPlusButtonPress = () => {
        setCount(count + 1)
    }

    const onMinusButtonPress = () => {
        if (count > 0) {
            setCount(count - 1)
        }
    }

    const onButtonPress = () => {
        item.item.count = count
        onUpdate()
        setIsUpdate(true)

        if (count === 0) {
            setIsUpdate(false)
        }

        setClicked(false)
    }

    return (
        <ListItem
            style={styles.productItem}
            onPress={click}>
            <View style={styles.content}>
                <Text category='s1'>{item.item.name} <Count count={item.item.count} /></Text>
                <Text appearance='hint' category='s2'>
                    {item.item.description}
                </Text>
                <PriceTag price={item.item.price} count={item.item.count} />
            </View>

            <ImageBackground
                style={styles.itemHeader}
                source={{ uri: item.item.imageUrl }}
                imageStyle={{ borderRadius: 9, flex: 1 }}
            />
            <Modal
                backdropStyle={styles.backdrop}
                visible={clicked}
                onBackdropPress={() => {
                    setClicked(false)
                }}>
                <Layout
                    level='3'
                    style={styles.modalContainer}>
                    <ImageBackground
                        style={styles.modalHeaderImage}
                        source={{ uri: item.item.imageUrl }}
                        imageStyle={{ borderTopLeftRadius: 32, borderTopRightRadius: 32 }}>
                    </ImageBackground>

                    <View style={{ paddingHorizontal: 16 }}>
                        <Text style={{ ...material.headline, ...systemWeights.semibold, color: colors.green, paddingVertical: 8 }}>{item.item.name}</Text>
                        <Text appearance='hint' category='s2'>
                            {item.item.description}
                        </Text>

                        <View style={{ marginTop: 8 }}>
                            <Text style={[material.subheading, systemWeights.semibold]}>Add on</Text>

                            <Addons data={addons} />
                        </View>
                    </View>

                    <View>
                        <View style={styles.amountContainer}>
                            <TouchableOpacity
                                style={styles.amountButton}
                                onPress={onMinusButtonPress}>
                                <MinusIcon width={24} height={24} fill={colors.green} alignSelf='center' />
                            </TouchableOpacity>
                            <Text style={styles.amount}>{count}</Text>
                            <TouchableOpacity
                                style={styles.amountButton}
                                onPress={onPlusButtonPress}>
                                <PlusIcon width={24} height={24} fill={colors.green} alignSelf='center' />
                            </TouchableOpacity>
                        </View>
                    </View>

                    <SingleButton onPress={onButtonPress} text={count > 0 ? `Add to cart $${item.item.price * count}` : `Cancel`} style={[{ paddingHorizontal: 60 }, count === 0 && { backgroundColor: colors.grey }]} />
                </Layout>
            </Modal>
        </ListItem >)
}

export const Addon = ({ text, selected, style }) => {
    const [isSelected, setIsSelected] = React.useState(selected)

    return (
        <TouchableOpacity
            style={[styles.addonButton, isSelected && { backgroundColor: colors.active }, style]}
            onPress={() => setIsSelected(!isSelected)}>
            <Text style={isSelected ? styles.addonTextActive : styles.addonText}>{text}</Text>
        </TouchableOpacity>
    )
}

const Addons = ({ data }) => (
    <View style={{ flexDirection: 'row', flexWrap: 'wrap', marginVertical: 8 }}>
        {data.map(box => (
            <Addon text={box.text} selected={box.selected} />
        ))}
    </View>
)


const Count = (props) => (
    <>
        {props.count > 0 && <Text category='s1' style={{ fontWeight: 'normal', color: colors.green }}>{` x${props.count}`}</Text>}
    </>
)

const MenuVerticalList = (props) => {
    const [update, setUpdate] = React.useState(false)

    const onUpdate = () => {
        setUpdate(!update)
        props.onChange()
    }

    log.variable({ menuItems: props.menuItems[0]['visible'] })

    return (<List
        contentContainerStyle={props.style}
        data={props.menuItems}
        renderItem={nfo => nfo.item.visible ? <RenderProductItem item={nfo} onUpdate={onUpdate} /> : <></>}
        style={{ flex: 1, backgroundColor: colors.white }}
        ListHeaderComponent={props.header}
        ItemSeparatorComponent={Divider}
        extraData={update}
    />
    )
}

const shadowStyle = {
    shadowColor: "#000",
    shadowOffset: {
        width: 0,
        height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,

    elevation: 5,
}

const styles = StyleService.create({
    container: {
        flex: 1,
        backgroundColor: 'background-basic-color-2',
    },
    productItem: {
        flex: 1,
        paddingHorizontal: 16
    },
    itemHeader: {
        height: 80,
        width: 80,
        marginLeft: 8
    },
    content: {
        flex: 1
    },

    amountContainer: {
        flexDirection: 'row',
        paddingBottom: 8
    },
    amountButton: {
        borderRadius: 8,
        paddingHorizontal: 0,
        borderColor: 'transparent',
        backgroundColor: colors.white,
        borderRadius: 32,



        width: 40,
        height: 40,
        ...shadowStyle,
        justifyContent: 'center'
    },
    amount: {
        ...material.display1,
        textAlign: 'center',
        paddingHorizontal: 32,
        textAlignVertical: 'center',
        color: colors.green,
        fontWeight: 'bold'
    },
    removeButton: {
        right: 0,
    },
    modalContainer: {
        alignItems: 'center',
        width: Dimensions.get('window').width - 32,
        borderRadius: 32,
        paddingBottom: 24,
        backgroundColor: colors.white
    },
    backdrop: {
        backgroundColor: 'rgba(0, 0, 0, 0.5)',
    },
    modalHeaderImage: {
        width: '100%',
        height: 192,
        borderTopLeftRadius: 32,
        borderTopRightRadius: 32
    },
    addonButton: {
        backgroundColor: colors.lightGrey,
        borderRadius: 32,
        height: 32,
        width: 'auto',
        paddingHorizontal: 16,
        flexDirection: 'column',
        justifyContent: 'center',
        marginBottom: 16,
        marginRight: 4
    },
    addonText: {
        ...material.caption,
        fontWeight: 'bold'
    },
    addonTextActive: {
        ...material.captionWhite,
        fontWeight: 'bold'
    },
});

export default MenuVerticalList