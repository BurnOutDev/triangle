import React from 'react'
import { View, ScrollView, ImageBackground, Text as RNText } from 'react-native'
import MenuHorizontalList from './Menu/MenuHorizontalList'
import { TouchableOpacity } from 'react-native-gesture-handler'
import { Text, Divider, StyleService, Avatar } from '@ui-kitten/components'
import { colors } from '../variables/colors'
import { material, systemWeights } from 'react-native-typography'
import { avatar } from '../variables/temp'
import { StarIcon } from './Icons'

const allowedCharacterCount = 112

const ReviewBar = ({ title, value }) => (
    <View style={styles.reviewContainer}>
        <Text style={styles.reviewBarTitle}>{title}</Text>
        <View style={styles.reviewBarContainer}>
            <Divider style={{ width: `${value}%`, ...styles.reviewBar }} />
        </View>
    </View>
)

const ReviewStars = ({ value }) => (
    <View style={styles.starsContainer}>
        {[1, 2, 3, 4, 5].map(index => {
            let filled = value - index >= 0

            return (<StarIcon width={16} height={16} fill={filled ? colors.gold : colors.grey} {...styles.star} />)
        })}
        <Text style={styles.reviewCount}>{value}</Text>
    </View>
)

const ReviewContent = ({ content }) => {
    const [expanded, setExpanded] = React.useState(false)

    let showReadMore = content.length > allowedCharacterCount
    let text = content

    if (showReadMore) {
        text = content.substring(0, allowedCharacterCount)
    }

    return (
        <Text style={styles.reviewText}>
            {expanded ? content : text} {showReadMore && (!expanded ? <RNText onPress={() => setExpanded(true)} style={[styles.reviewText, { color: colors.green }]}>Read more</RNText> : <RNText onPress={() => setExpanded(false)} style={[styles.reviewText, { color: colors.green }]}>Show less</RNText>)}
        </Text>
    )
}

const Reviews = (props) => {
    const [data, setData] = React.useState({
        reviews: [
            {
                name: 'Jenny Mo',
                avatar: avatar,
                followersCount: 300,
                reviewsCount: 125,
                review: 4.3,
                reviewContent: `I enjoyed the foods of the restaurant. The dishes are really nice and awesome. nice space and great view. I will come back here. Also I want to take more pictures`,
                pictures: [
                    require('../Mock/Get/Restaurant/Restaurant.json').image,
                    require('../Mock/Get/Restaurant/Restaurant.json').image,
                    require('../Mock/Get/Restaurant/Restaurant.json').image,
                    require('../Mock/Get/Restaurant/Restaurant.json').image
                ],
            },
            {
                name: 'Jenny Mo',
                avatar: avatar,
                followersCount: 300,
                reviewsCount: 125,
                review: 4.6,
                reviewContent: `I enjoyed the foods of the restaurant. The dishes are really nice and awesome. nice space and great view. I will`,
            }
        ]
    })

    return (<View style={{ paddingVertical: 8, paddingHorizontal: 16 }}>
        <View style={{ flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center', paddingBottom: 16 }}>
            <Text category='h4' style={{ fontWeight: 'bold' }}>Reviews</Text>
            <TouchableOpacity onPress={() => props.navigation.navigate('RestaurantMenu', { restaurantId: restaurant.restaurantId })}><Text style={{ color: colors.green }}>View all</Text></TouchableOpacity>
        </View>
        <View>
            <ReviewBar title='Food' value='90' />
            <ReviewBar title='Service' value='100' />
            <ReviewBar title='Value' value='70' />
        </View>

        {data.reviews.map(review => (
            <View style={{ paddingVertical: 16 }}>
                <View style={{ flexDirection: 'row' }}>
                    <Avatar source={{ uri: avatar }} style={{ alignSelf: 'center' }} />
                    <View style={{ flexDirection: 'column', paddingHorizontal: 8 }}>
                        <Text style={{ ...material.headline, ...systemWeights.bold }}>{review.name}</Text>
                        <Text style={{ ...material.caption }}>{review.followersCount} Followers, {review.reviewsCount} Reviews</Text>
                    </View>
                </View>
                <ReviewStars value={review.review} />
                <View>
                    {<ReviewContent content={review.reviewContent} />}
                    <View style={styles.reviewPicturesContainer}>
                        {review.pictures?.slice(0, 4).map((picture, index) => (
                            <ImageBackground
                                source={{ uri: picture }}
                                style={[styles.reviewPicture, index == 3 && styles.reviewPictureButton]}
                                imageStyle={styles.reviewPictureImageStyle}>
                                {index === 3 && <View style={[styles.reviewPictureButton, { backgroundColor: colors.transparentGrey, borderRadius: 8, height: '100%' }]}>
                                    <Text style={styles.reviewPictureButtonText}>+24</Text>
                                </View>}
                            </ImageBackground>
                        ))}
                    </View>
                </View>
            </View>
        ))}
    </View>
    )
}

const styles = StyleService.create({
    reviewBarTitle: {
        flex: 1,
        ...material.caption,
        fontSize: 14
    },
    reviewBar: {
        backgroundColor: colors.gold,
        alignSelf: 'flex-start',
        height: 4,
        borderRadius: 4
    },
    reviewContainer: {
        flexDirection: 'row',
        marginVertical: 4
    },
    reviewBarContainer: {
        flex: 4,
        alignSelf: 'center'
    },
    star: {
        marginHorizontal: 2
    },
    reviewCount: {
        ...material.subheading,
        ...systemWeights.semibold,
        textAlignVertical: 'center',
        paddingHorizontal: 4,
    },
    starsContainer: {
        flexDirection: 'row',
        marginVertical: 8,
        alignItems: 'center'
    },
    reviewText: {
        ...material.subheading,
        color: colors.grey
    },
    reviewPicture: {
        width: 64,
        height: 64
    },
    reviewPicturesContainer: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        paddingVertical: 16
    },
    reviewPictureImageStyle: {
        borderRadius: 8,
    },
    reviewPictureButton: {
        flexDirection: 'column',
        justifyContent: 'center',
    },
    reviewPictureButtonText: {
        textAlign: 'center',
        ...material.subheadingWhite
    }
})

export default Reviews