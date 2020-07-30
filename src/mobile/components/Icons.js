import React from 'react'
import { Icon } from "@ui-kitten/components";
import { colors } from '../variables/colors';


export const Search = (style) => (
    <Icon width='16' height='16' fill={colors.green} name='search' {...style} />
)

export const Location = (style) => (
    <Icon width='16' height='16' fill={colors.green} name='pin-outline' {...style} />
)

export const Pin = (style) => (
    <Icon width='16' height='16' fill={colors.green} name='pin-outline' {...style} />
)

export const Heart = (style) => (
    <Icon width='16' height='16' fill={colors.green} name='heart-outline' {...style} />
)

export const Person = (style) => (
    <Icon width='16' height='16' fill={colors.green} name='person-outline' {...style} />
)

export const ArrowRight = (style) => (
    <Icon width='16' height='16' fill={colors.green} name='chevron-right' {...style} />
)

export const Back = (style) => (
    <Icon width='16' height='16' fill={colors.green} name='arrow-back' {...style} />
);

export const Star = (style) => (
    <Icon width='16' height='16' name='star' fill={colors.gold} {...style} />
);

export const Filter = (style) => (
    <Icon width='16' height='16' name='funnel-outline' fill={colors.gold} {...style} />
)

export const MinusIcon = (style: ImageStyle): IconElement => (
    <Icon {...style} name='minus' />
);

export const PlusIcon = (style: ImageStyle): IconElement => (
    <Icon {...style} name='plus' />
);

export const ShareIcon = (style: ImageStyle): IconElement => (
    <Icon {...style} name='share-outline' />
);

export const PhotoIcon = (style: ImageStyle): IconElement => (
    <Icon {...style} name='camera-outline' />
);