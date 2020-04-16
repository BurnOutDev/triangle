import React from 'react'
import { View } from 'react-native'
import { Text, Button } from '@ui-kitten/components'

const ReferalPromo = () => (
    <View style={{ marginLeft: 15, marginRight: 15, marginBottom: 100, borderRadius: 10 }}>
        <Text category='h4' style={{ paddingHorizontal: 30, textAlign: 'center', fontWeight: 'bold' }}>Refer a friend and get $10 discount</Text>
        <Text category='c2' style={{ paddingHorizontal: 30, paddingVertical: 10, textAlign: 'center' }}>You can get $10 discount whenever you refer a friend to us and they book the first table.</Text>
        <Button style={{ maxWidth: 200, alignSelf: 'center' }}>Invite friends</Button>
    </View>
)

export default ReferalPromo